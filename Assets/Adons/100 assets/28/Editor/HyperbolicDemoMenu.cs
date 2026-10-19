#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

namespace Unauticna.HyperbolicSpace.Editor
{
    public static class HyperbolicDemoMenu
    {
        [MenuItem("Tools/Unauticna/Hyperbolic Space/Create Demo Scene")]
        public static void CreateDemo()
        {
            if(EditorApplication.isPlaying)
            { EditorUtility.DisplayDialog("Hyperbolic Space","Stop Play Mode first.","OK");return; }
            var pipeline=GraphicsSettings.currentRenderPipeline;
            if(pipeline!=null && pipeline.GetType().Name.Contains("HDRender"))
            {
                EditorUtility.DisplayDialog("Hyperbolic Space",
                    "Demo shaders target Built-in and URP. In HDRP, assign compatible materials on HyperbolicStarfield before Play.","OK");
            }
            if(!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())return;
            var scene=EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
            var cameraObject=new GameObject("Hyperbolic Camera");
            cameraObject.tag="MainCamera";
            var camera=cameraObject.AddComponent<Camera>();
            camera.clearFlags=CameraClearFlags.SolidColor;camera.backgroundColor=Color.black;
            camera.nearClipPlane=.02f;camera.farClipPlane=200;camera.fieldOfView=70;
            cameraObject.AddComponent<AudioListener>();
            var h3=cameraObject.AddComponent<HyperbolicCamera3D>();
            cameraObject.AddComponent<HyperbolicOriginGuide>();
            var fieldObject=new GameObject("Hyperbolic Starfield (StaticEcs)");
            var field=fieldObject.AddComponent<HyperbolicStarfield>();field.hyperbolicCamera=h3;
            // Put the nearest deterministic star in front of the camera for the first flight.
            var settings=new StarGenerationSettings {CurvatureRadius=20,VisibleRadius=2.6m,Density=.8m,SphereRadius=1.2m,Capacity=2048,WorkerCount=1};
            var stars=HyperbolicStars.Generate(H3Point.Origin,settings,System.Threading.CancellationToken.None,out _);
            if(stars.Length>0)
            {
                stars[0].Position.TryToLocal(MegaPoint.Origin,out H3Point relative);
                DVec3 direction=H3Math.LogDirection(H3Point.Origin,relative,out _);
                var forward=new Vector3((float)direction.X,(float)direction.Y,(float)direction.Z);
                cameraObject.transform.rotation=Quaternion.LookRotation(forward,Mathf.Abs(Vector3.Dot(forward,Vector3.up))>.98f?Vector3.forward:Vector3.up);
            }
            var lightObject=new GameObject("Light for custom static models");
            var light=lightObject.AddComponent<Light>();light.type=LightType.Directional;light.intensity=1.3f;
            lightObject.transform.rotation=Quaternion.Euler(45,-30,0);
            RenderSettings.ambientLight=new Color(.25f,.25f,.3f);
            EditorSceneManager.MarkSceneDirty(scene);
            Selection.activeGameObject=fieldObject;
            EditorGUIUtility.PingObject(fieldObject);
            Debug.Log("H3 demo created. Press Play and fly toward a star. Assign static prefabs in Model Prefabs for your own interiors.");
        }
    }
}
#endif
