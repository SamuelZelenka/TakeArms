using System.Collections;
using System.Collections.Generic;
using Targeting;
using UnityEngine;

public class RepositoryService : MonoBehaviour
{
    #region INSTANCE
    private static RepositoryService _instance;
    public static RepositoryService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(new GameObject().AddComponent<RepositoryService>());
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField]
    private TargetVisualizeConfigRepository _targetVisualizeConfigRepository;
    public TargetVisualizeConfigRepository TargetVisualizeConfigRepository => _targetVisualizeConfigRepository;
}
