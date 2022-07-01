using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSystem : MonoBehaviour
{
    #region INSTANCE
    private static RootSystem _instance;
    public static RootSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RootSystem();
            }
            return _instance;
        }
    }
    #endregion

    public RootSystem(){}
}
