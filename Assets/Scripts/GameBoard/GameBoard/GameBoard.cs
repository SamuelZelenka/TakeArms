using System;
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public string mapName;

    public Dictionary<ulong, GameUnit> gameUnits;

    public Terrain groundTerrain;
    public TerrainCollider groundTerrainCollider;
    
    #region INSTANCE
    private static GameBoard _instance;
    public static GameBoard Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameBoard>();
                if (_instance == null)
                {
                    Debug.LogWarning("There is no GameBoard in the scene.");
                }
            }
            return _instance;
        }
    }
    #endregion
    
    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _gameState = new GameState();
        mapName = mapName.Split('.')[0];
        MapLayoutData activeMap = MapLayoutData.GetMapByName(mapName);
        groundTerrain = Terrain.activeTerrains[0];
        groundTerrainCollider = groundTerrain.GetComponent<TerrainCollider>();
    }

    public Vector3 GetTerrainPosFromRay(Ray ray)
    {
        groundTerrainCollider.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
        return hit.point;
    }
    public float GetTerrainHeightFromPosition(Vector3 worldPosition)
    {
        return groundTerrain.SampleHeight(worldPosition);
    }

    public void InstantiateUnit<TUnitType>(uint UnitRepositoryID, Vector2Int boardPosition) where TUnitType : UnitData
    {
        
    }
    
    private GameState _gameState;

    #region Saving/Loading
    
    public void LoadGame(GameState gameState)
    {
        throw new NotImplementedException();
    }

    public GameState SaveGame()
    {
        throw new NotImplementedException();
    }
    #endregion
}
