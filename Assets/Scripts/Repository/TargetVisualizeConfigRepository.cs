using System;
using System.Collections.Generic;
using ScriptableObjects.TargetVisualizers;
using UnityEngine;


namespace Targeting
{
    [CreateAssetMenu(fileName = "new TargetVisualConfig", menuName = "Targeting/Targeting Visualize Config Repository", order = 0)]
    public class TargetVisualizeConfigRepository : ScriptableObject
    {
        [SerializeField] private TargetVisualizerConfiguration[] _visualizerConfigs;
        
        private Dictionary<ulong, TargetVisualizerConfiguration> _visualizers = new Dictionary<ulong, TargetVisualizerConfiguration>();

        public TargetVisualizerConfiguration GetVisualizeConfig(ulong id)
        {
            if (_visualizers?.Count == 0)
            {
                for(ulong i = 0; i < (ulong)_visualizerConfigs.Length; i++)
                {
                    _visualizers.Add(GetAvailableID(), _visualizerConfigs[i]);
                    _visualizerConfigs[i].visualizerID = i;
                }
            }

            TargetVisualizerConfiguration config = null;
            _visualizers.TryGetValue(id, out config);
            Debug.Assert(config,$"Target Visualizer ID:{id} was not found ");
            return config;
        }
        private ulong GetAvailableID()
        {
            for (ulong i = 0; i < ulong.MaxValue; i++)
            {
                if (!_visualizers.ContainsKey(i))
                    return i;
            }
            Debug.LogError("We should not run out of visualizer ID's");
            return ulong.MaxValue;
        }
    }
}
