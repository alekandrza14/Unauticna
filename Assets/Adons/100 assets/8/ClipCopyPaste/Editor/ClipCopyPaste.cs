using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace GamesOyo.ClipCopyPaste.Editor
{
	/// <summary>
	/// Utility to copy and paste Unity objects across projects via using Json.
	/// </summary>
	/// <author>Victor Nascimento</author>
	static class ClipCopyPaste
	{
		[MenuItem("CONTEXT/Object/Clip CopyPaste/Copy")]
		static void CopyComponent(MenuCommand command)
		{
			if (command.context is not Object target)
			{
				return;
			}

			var json = EditorJsonUtility.ToJson(target, true);

			GUIUtility.systemCopyBuffer = RemoveNameProperty(json);
		}

		//Remove the property name, because if dealing with assets this can corrupt the library version
		static string RemoveNameProperty(string jsonString)
		{
			string pattern = "\"m_Name\":[^\"]*\"[^\"]*\"(,),?";
			return Regex.Replace(jsonString, pattern, "");
		}

		[MenuItem("CONTEXT/Object/Clip CopyPaste/Paste")]
		static void PasteComponent(MenuCommand command)
		{
			if (string.IsNullOrEmpty(GUIUtility.systemCopyBuffer) ||
				command.context is not Object target)
			{
				return;
			}

			Undo.RegisterCompleteObjectUndo(target, "Clip Paste");
			EditorJsonUtility.FromJsonOverwrite(GUIUtility.systemCopyBuffer, target);
			EditorUtility.SetDirty(target);
		}

		[MenuItem("GameObject/Clip CopyPaste/Copy", priority = 0)]
		static void CopyGameObject(MenuCommand command)
		{
			if (command.context is not GameObject gameObject)
			{
				return;
			}

			FauxGameObject.Copy(gameObject, false);
		}

		[MenuItem("GameObject/Clip CopyPaste/Copy With Children", priority = 0)]
		static void CopyGameObjectWithChildren(MenuCommand command)
		{
			if (command.context is not GameObject gameObject)
			{
				return;
			}

			FauxGameObject.Copy(gameObject, true);
		}

		[MenuItem("GameObject/Clip CopyPaste/Paste", priority = 0)]
		static void PasteGameObject(MenuCommand command)
		{
			if (string.IsNullOrEmpty(GUIUtility.systemCopyBuffer) ||
				command.context is not GameObject gameObject)
			{
				return;
			}

			Component[] components = gameObject.GetComponents<Component>();

			Object[] objectsToUndo = new Object[components.Length + 1];

			for (int i = 0; i < components.Length; i++)
			{
				objectsToUndo[i] = components[i];
			}

			objectsToUndo[objectsToUndo.Length - 1] = gameObject;

			Undo.RegisterCompleteObjectUndo(objectsToUndo, "Clip Paste");
			FauxGameObject.Apply(gameObject);
		}

		#region Utility Internal Classes
		[System.Serializable]
		class FauxGameObject
		{
			public string Content { get; set; }

			public FauxComponent[] Components { get; set; }

			public FauxGameObject[] Children { get; set; }

			public string Name { get; set; }

			public FauxGameObject() { }

			public static void Copy(GameObject target, bool isCopyingChildren)
			{
				var source = CreateFrom(target, isCopyingChildren);

				GUIUtility.systemCopyBuffer = JsonConvert.SerializeObject(source, Formatting.Indented);
			}

			static FauxGameObject CreateFrom(GameObject target, bool isCopyingChildren)
			{
				Component[] components = target.GetComponents<Component>();

				int childCount = 0;

				if (isCopyingChildren)
				{
					childCount = target.transform.childCount;
				}

				FauxGameObject source = new FauxGameObject
				{
					Content = EditorJsonUtility.ToJson(target, true),

					Components = new FauxComponent[components.Length],

					Name = target.name,

					Children = new FauxGameObject[childCount],
				};

				for (int i = 0; i < components.Length; i++)
				{
					source.Components[i] = new FauxComponent(components[i]);
				}

				for (int i = 0; i < childCount; i++)
				{
					source.Children[i] = CreateFrom(target.transform.GetChild(i).gameObject, isCopyingChildren);
				}

				return source;
			}

			public static void Apply(GameObject target)
			{
				FauxGameObject source = JsonConvert.DeserializeObject<FauxGameObject>(GUIUtility.systemCopyBuffer);

				source.ApplyOn(target);
			}

			void ApplyOn(GameObject target)
			{
				EditorJsonUtility.FromJsonOverwrite(Content, target);

				for (int i = 0; i < Components.Length; i++)
				{
					var component = Components[i];

					if (component.Type == null)
					{
						Debug.LogError($"Failed to find type with name: {component.TypeName}");
						continue;
					}

					if (!target.TryGetComponent(component.Type, out var targetComponent))
					{
						targetComponent = target.AddComponent(component.Type);
					}

					EditorJsonUtility.FromJsonOverwrite(component.Content, targetComponent);
					EditorUtility.SetDirty(targetComponent);
				}

				Transform targetTransform = target.transform;

				int childCount = targetTransform.childCount;

				for (int i = 0; i < Children.Length; i++)
				{
					for (int j = 0; j < childCount; j++)
					{
						Transform child = targetTransform.GetChild(j);
						if (child.name == Children[i].Name)
						{
							Children[i].ApplyOn(child.gameObject);

							break;
						}
					}
				}

				EditorUtility.SetDirty(target);
			}
		}

		[System.Serializable]
		class FauxComponent
		{
			public System.Type Type { get; set; }
			public string Content { get; set; }
			public string TypeName { get; set; }

			public FauxComponent() { }

			public FauxComponent(Component target)
			{
				Type = target.GetType();
				TypeName = Type.FullName;

				Content = EditorJsonUtility.ToJson(target, true);
			}
		}
		#endregion
	}
}
