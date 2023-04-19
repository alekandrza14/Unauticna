using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("EditorTags/Tag-1")]
[ExecuteInEditMode]
public class EditorTag1 : MonoBehaviour
{
    public string newTag;
    void Update()
    {
        gameObject.tag = newTag;
    }
}
