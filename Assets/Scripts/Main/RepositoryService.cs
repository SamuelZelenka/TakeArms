using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Targeting;
using UnityEditor;
using UnityEngine;

public class RepositoryService : ScriptableObject
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
    [OnValueChanged("SaveUnitConfigRepository")]
    private UnitRepository _unitConfigRepository;

    private void SaveUnitConfigRepository()
    {
        AssetDatabase.SaveAssets();
    }
    public static UnitRepository UnitConfigRepository => Instance._unitConfigRepository;
}
