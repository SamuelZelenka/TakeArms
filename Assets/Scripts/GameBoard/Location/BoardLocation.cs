using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BoardLocation : MonoBehaviour
{
    private LocationData _locationData;
    private TileData[] _tileGrid = new TileData[64];
    private int _gridSize;

    public TileData GetTileData(Vector2Int pos)
    {
        int index = pos.y * 8 + pos.x;
        if (_tileGrid[index] == null)
        {
            _tileGrid[index] = new TileData();
        }
        
        return _tileGrid[index];
    }

    private void OnDrawGizmos()
    {
        _gridSize = (int)Mathf.Sqrt(_tileGrid.Length);
        for (int x = 0; x < _gridSize; x++)
        {
            for (int y = 0; y < _gridSize; y++)
            {
                DrawTileState(x,y);
            }
        }
        void DrawTileState(int x, int y)
        {
            switch (GetTileData(new Vector2Int(x,y)).currentState)
            {
                case TileData.TileState.Empty:
                    break;
                case TileData.TileState.Occupied:
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(new Vector3(x + 0.5f,y + 0.5f,0) ,0.5f);
                    break;
                case TileData.TileState.WeakCover:
                    Gizmos.color = Color.grey;
                    Gizmos.DrawSphere(new Vector3(x + 0.5f,y + 0.5f,0) ,0.5f);
                    break;
                case TileData.TileState.SolidCover:
                    Gizmos.color = Color.black;
                    Gizmos.DrawSphere(new Vector3(x + 0.5f,y + 0.5f,0)  ,0.5f);
                    break;
            }
        }
    }
}
