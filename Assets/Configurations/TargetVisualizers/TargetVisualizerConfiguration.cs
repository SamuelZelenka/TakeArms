using UnityEngine;

namespace ScriptableObjects.TargetVisualizers
{
    [CreateAssetMenu(fileName = "new TargetVisualConfig", menuName = "Targeting/Visualizer", order = 0)]
    public class TargetVisualizerConfiguration : ScriptableObject
    {
        [SerializeField]
        private GameObject _visualPrefab;
        public GameObject VisualPrefab => _visualPrefab;
    }
}