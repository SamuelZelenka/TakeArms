using System;
using Targeting;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace ScriptableObjects.TargetVisualizers
{
    [CreateAssetMenu(fileName = "new TargetVisualConfig", menuName = "Targeting/Visualizer", order = 0)]
    public class TargetVisualizerConfiguration : ScriptableObject
    {
        public ulong visualizerID;
        
        [SerializeField]
        private GameObject _visualPrefab;
        
        public GameObject VisualPrefab => _visualPrefab;
    }

    public class TargetVisualizeInspectorEditor : Editor
    {
        
    }
    
}