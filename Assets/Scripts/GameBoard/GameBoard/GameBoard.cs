using System;
using GameData;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public string mapName;
    
    private void Start()
    {
        _gameState = new GameState();
        mapName = mapName.Split('.')[0];
        MapLayoutData activeMap = MapLayoutData.GetMapByName(mapName);
        _gameState.tileLayout = GetBoardTilesFromData(activeMap);
    }

    private GameState _gameState;
    
    public void PlaceUnit(int unitId, Vector2Int tilePos, Vector2Int unitPosition)
    {
        throw new NotImplementedException();
    }

    public void MoveUnit(Vector2Int fromTile, Vector2Int fromPosition, Vector2Int toTile, Vector2Int toPosition)
    {
        throw new NotImplementedException();
    }

    #region Saving/Loading
    
    public void LoadGame(GameState gameState)
    {
        throw new NotImplementedException();
    }

    public GameState SaveGame()
    {
        throw new NotImplementedException();
    }

    private static LocationData[,] GetBoardTilesFromData(MapLayoutData layoutData)
    {
        int gridSize = layoutData.GridSize;
        int[,] tileIndices = layoutData.GetGrid();
        LocationData[,] boardTiles = new LocationData[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (tileIndices[x,y] != 0)
                {
                    boardTiles[x, y] = new LocationData();  
                }
            } 
        }
        return boardTiles;
    }
    #endregion
}
