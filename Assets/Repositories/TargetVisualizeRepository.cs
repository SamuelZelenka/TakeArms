using System;
using System.Collections.Generic;
using ScriptableObjects.TargetVisualizers;
using UnityEngine;

namespace Repositories
{
    public class TargetVisualizeRepository
    {
        private Dictionary<UInt64, TargetVisualizerConfiguration> _visualizers;

        public TargetingVisualizer GetVisualizer(UInt64 id)
        {
            throw new NotImplementedException();
        }
    }
}