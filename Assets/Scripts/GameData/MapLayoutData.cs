using TakeArms.Utility;

using System;
using UnityEngine;


namespace TakeArms.GameData
{
    [Serializable]
    public class MapLayoutData : ISavable
    {
        public static readonly string FILE_TYPE = ".map";
        public static readonly string MAP_DIRECTORY = "Maps";
        public static readonly string SAVE_DIRECTORY = Application.dataPath + $"/{MAP_DIRECTORY}/";

        [SerializeField] private string _mapName = "New Map";
        [SerializeField] private int[] _tileGrid;
        
        public int GridSize => (int) Mathf.Sqrt(_tileGrid.Length); 
        
        public MapLayoutData(int[] tiles, string mapName)
        {
            _mapName = mapName;
            _tileGrid = tiles;
        }

        public int[,] GetGrid()
        {
            int tileIndex = 0;
            
            int[,] grid = new int[GridSize, GridSize];

            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    grid[x, y] = _tileGrid[tileIndex];
                    tileIndex++;
                }
            }

            return grid;
        }

        public int[] GetAllTiles() => _tileGrid;

        public string GetSaveString()
        {
            return JsonUtility.ToJson(this);;
        }

        public static MapLayoutData GetMapByName(string fileName) => SaveSystem.LoadData<MapLayoutData>(fileName, MapLayoutData.MAP_DIRECTORY, MapLayoutData.FILE_TYPE);
        
        public static string[] GetExistingMaps()
        {
            string directoryPath = SaveSystem.GetDirectoryPath(MAP_DIRECTORY);
            string[] filePaths = SaveSystem.GetFilesOfType(FILE_TYPE, MAP_DIRECTORY);
            string[] mapsInDirectory = new string[filePaths.Length];

            if (mapsInDirectory.Length > 0)
            {
                for (int i = 0; i < mapsInDirectory.Length; i++)
                {
                    mapsInDirectory[i] = filePaths[i].Remove(0, directoryPath.Length);
                }
            }
            return mapsInDirectory;
        }
    }
}
