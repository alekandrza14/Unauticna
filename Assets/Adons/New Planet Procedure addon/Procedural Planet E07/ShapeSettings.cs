using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace na1
{
    [CreateAssetMenu()]
    public class ShapeSettings : ScriptableObject
    {

        public float planetRadius = 1;
        public NoiseLayer[] noiseLayers;

        [System.Serializable]
        public class NoiseLayer
        {
            public bool enabled = true;
            public bool useFirstLayerAsMask;
            public NoiseSettings noiseSettings;
        }
    }
}