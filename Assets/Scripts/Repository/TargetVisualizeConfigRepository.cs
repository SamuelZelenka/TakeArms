using System;
using System.Collections.Generic;
using ScriptableObjects.TargetVisualizers;
using UnityEngine;


namespace Targeting
{
    [CreateAssetMenu(fileName = "new TargetVisualConfig", menuName = "Targeting/Targeting Visualize Config Repository", order = 0)]
    public class TargetVisualizeConfigRepository : Repository<TargetVisualizerConfiguration>
    {
        protected override TargetVisualizerConfiguration GetConfiguration(ulong id)
        {
            TargetVisualizerConfiguration config = base.GetConfiguration(id);
            Debug.Assert(config, $"TargetVisualizer with ID: [{id}] was not found");
            return config;
        }
    }
}
