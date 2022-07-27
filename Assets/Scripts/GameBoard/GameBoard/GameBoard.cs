using System;
using System.Collections.Generic;
using Configurations;
using GameData;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public string mapName;

    public List<GameUnit> gameUnits = new List<GameUnit>();

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
        InstantiateUnit(0, new Vector2Int(0,0));

        _gameState = new GameState();
        mapName = mapName.Split('.')[0];
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

    public static Vector3 GetWorldPosFromBoardPos(Vector2Int boardPos)
    {
        float worldPosX = boardPos.x;
        float worldPosZ = boardPos.y;
        float worldPosY = Instance.GetTerrainHeightFromPosition(new Vector3(worldPosX,0,worldPosZ));
        return new Vector3(worldPosX, worldPosY, worldPosZ);
    }

    public static void MoveGameUnit(GameUnit unit, Vector2Int newPosition)
    {
        Instance.gameUnits.Find(x => x == unit).boardPosition = newPosition;
    }

    public void InstantiateUnit(ulong unitConfigID, Vector2Int boardPosition)
    {
        UnitConfiguration newConfig = RepositoryService.UnitConfigRepository.GetItem(unitConfigID);
        
        GameUnit newUnit = new GameObject().AddComponent<GameUnit>();
        newUnit.unitConfig = newConfig;
        newUnit.boardPosition = boardPosition;
        newUnit.unitConfig.InitObject(newUnit.transform);
        gameUnits.Add(newUnit);
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
