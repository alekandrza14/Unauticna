using System;
using UnityEngine;


namespace UnityStandardAssets.Cameras
{
    public abstract class PivotBasedCameraRig : AbstractTargetFollower
    {
        // This script is designed to be placed on the root object of a HB_Camera rig,
        // comprising 3 gameobjects, each parented to the next:

        // 	Camera Rig
        // 		Pivot
        // 			Camera

        protected Transform m_Cam; // the transform of the HB_Camera
        protected Transform m_Pivot; // the point at which the HB_Camera pivots around
        protected Vector3 m_LastTargetPosition;


        protected virtual void Awake()
        {
            // find the HB_Camera in the object hierarchy
            m_Cam = GetComponentInChildren<Camera>().transform;
            m_Pivot = m_Cam.parent;
        }
    }
}
