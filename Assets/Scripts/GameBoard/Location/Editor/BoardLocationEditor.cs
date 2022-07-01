using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MapEditors
{
    [CustomEditor(typeof(BoardLocation))]
    public class BoardLocationEditor : Editor
    {
        
        private bool isEnabled = false;
        int gridSize = 8;
        private Vector2Int lastClickedPos;
        private string[] tileStates;
        private BoardLocation _currentLocation;
        
        private void OnEnable()
        {
            
            _currentLocation = (BoardLocation)target;
            tileStates = Enum.GetNames(typeof(TileData.TileState));
            isEnabled = true;
        }

        private void OnDisable()
        {
            isEnabled = false;
       
        }
        

        private void OnSceneGUI()
        {
            Handles.BeginGUI();
            Vector2 mousePos = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            int mouseButtonClicked = Event.current.button;
            
            if (mouseButtonClicked == 1)
            {
                RaycastHit hitInfo;
                Ray clickedRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                
                Vector2 mousePosition = Event.current.mousePosition;
                mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
                mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);

                lastClickedPos.Set((int)mousePosition.x, (int)mousePosition.y);
                
                Physics.Raycast(clickedRay, out hitInfo, Mathf.Infinity);
            }
            TileData selectedTile = _currentLocation.GetTileData(lastClickedPos);
            
            selectedTile.currentState = (TileData.TileState)GUILayout.SelectionGrid((int)selectedTile.currentState, tileStates, tileStates.Length);
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    bool isTileClickedOn = lastClickedPos.x == x && lastClickedPos.y == y;
                    if (!isTileClickedOn)
                    {
                        DrawTile(x, y, Color.white);
                    }
                }
            }
            DrawTile(lastClickedPos, Color.red);
            Handles.EndGUI();
        }

        private void DrawTile(Vector2Int pos, Color color) => DrawTile(pos.x, pos.y, color);
        private void DrawTile(int x, int y, Color color)
        {
            int squareWidth = 1;

            Vector3 bottomleft = new Vector3(x,y,0);
            Vector3 bottomRight = new Vector3(x + squareWidth,y,0);
            Vector3 topLeft = new Vector3(x,y + squareWidth,0);
            Vector3 topRight = new Vector3(x + squareWidth,y + squareWidth,0);

            Debug.DrawLine(bottomleft, bottomRight, color);
            Debug.DrawLine(bottomleft, topLeft, color);
            Debug.DrawLine(bottomRight, topRight, color);
            Debug.DrawLine(topLeft, topRight, color);
        }
    }
}