using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using TakeArms.Targeting;
using UnityEditor;
using UnityEngine;

namespace TakeArms.Services
{
    public class RepositoryService : SerializedScriptableObject
    {
        private const string RESOURCE_PATH = "Repository/RepositoryService";
        private const string PATH = "Assets/Resources/" + RESOURCE_PATH;

        #region INSTANCE

        private static RepositoryService _instance;

        public static RepositoryService Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = Resources.Load<RepositoryService>(RESOURCE_PATH);

                if (_instance != null)
                    return _instance;

#if UNITY_EDITOR
                _instance = CreateInstance<RepositoryService>();
                AssetDatabase.CreateAsset(_instance, PATH + ".asset");
#endif

                return _instance;
            }
        }

        #endregion

        [ShowInInspector]
        [OdinSerialize] 
        [BoxGroup("Units")]
        private UnitRepository _unitConfigRepository;

        [ShowInInspector]
        [OdinSerialize]
        [BoxGroup("Visualizer")]
        private NodeVisualizer _nodeVisualizerPrefab;
        public static UnitRepository UnitConfigRepository => Instance._unitConfigRepository;
        public static NodeVisualizer NodeVisualizerPrefab => Instance._nodeVisualizerPrefab;

        public static ulong GetUniqueID<TVal>(IDictionary<ulong, TVal> collection)
        {
            // 0 = invalid ID
            for (ulong i = 1; true; i++)
                if (!collection.ContainsKey(i))
                    return i;
        }
    }
}
