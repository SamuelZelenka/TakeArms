using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Targeting;
using UnityEditor;
using UnityEngine;

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
                
            _instance = CreateInstance<RepositoryService>();
            AssetDatabase.CreateAsset(_instance, PATH + ".asset");
            return _instance;
        }
    }
    #endregion
    
    [ShowInInspector]
    [OdinSerialize]
    private UnitRepository _unitConfigRepository;
    public static UnitRepository UnitConfigRepository => Instance._unitConfigRepository;
}
