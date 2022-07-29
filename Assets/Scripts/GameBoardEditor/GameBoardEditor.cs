using TakeArms.GameData;
using TakeArms.Systems;
using TakeArms.Utility;

using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardEditor : MonoBehaviour
{
    private string[] _existingMaps;
    private int _selectedMapIndex;

    [SerializeField] private GameBoard _activeGameBoard;

    [SerializeField] private TMP_Text _gridSizeText;
    [SerializeField] private Slider _gridSizeSlider;
    [SerializeField] private TMP_Text[] _mapName;
    [SerializeField] private TMP_Dropdown _existingMapsDropDown;
    [SerializeField] private TMP_InputField _inputfield;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _saveButton;

    private void Start()
    {
        UpdateMapsDropDown();
        DrawOptions();
        _gridSizeSlider.minValue = 2;
        _gridSizeSlider.maxValue = 100;
    }

    public void UpdateMapsDropDown()
    {
        UpdateExistingMapsOptions();
        _existingMapsDropDown.options.Clear();
        foreach (string existingMap in _existingMaps)
        {
            _existingMapsDropDown.options.Add(new TMP_Dropdown.OptionData(existingMap));
        }
        _selectedMapIndex = _existingMapsDropDown.value;
    }

    public void UpdateGridSize()
    {
        _gridSizeText.text = "GridSize: " + _gridSizeSlider.value;
    }
    
    public void DrawOptions()
    {
        UpdateMapsDropDown();
            
            if (_selectedMapIndex == 0)
            {
                _inputfield.gameObject.SetActive(true);
                _loadButton.gameObject.SetActive(false);
                _saveButton.gameObject.SetActive(_inputfield.text.Length > 0);
            }
            else
            {
                string selectedMapFile = _existingMaps[_selectedMapIndex];
                SelectMap(selectedMapFile);
                _inputfield.gameObject.SetActive(false);
                _loadButton.gameObject.SetActive(true);
                _saveButton.gameObject.SetActive(true);
            }
            
            void SelectMap(string mapFileName)
            {
                string[] fileNameSplit =mapFileName.Split('.');
                _existingMaps[_selectedMapIndex] = fileNameSplit[0];
            }
        }
        
        public void SaveCurrentMap()
        {
            string filename = _inputfield.text;
            string directory = MapLayoutData.MAP_DIRECTORY;
            string dataString = "";
            string fileType = MapLayoutData.FILE_TYPE;
            
            List<int> tileIndices = new List<int>();

            //Insert saving here

            MapLayoutData newMap = new MapLayoutData(tileIndices.ToArray(), filename);
            dataString = newMap.GetSaveString();

            SaveSystem.SaveData(filename, directory, dataString, fileType);
            UpdateMapsDropDown();
            
            for (int i = 0; i < _existingMaps.Length; i++)
            {
                if (filename + $"{fileType}" == _existingMaps[i])
                {
                    _selectedMapIndex = i;
                    break;
                }
            }
        }
        
        public void LoadSelectedMap()
        {
            MapLayoutData loadedData = MapLayoutData.GetMapByName(_existingMaps[_selectedMapIndex]);

            if (loadedData == null)
            {
                Debug.LogError($"Could not load map {_existingMaps[_selectedMapIndex]}");
                return;
            }
            //Insert Loading Here
        }
        
        private void UpdateExistingMapsOptions()
        {
            string[] existingMaps = MapLayoutData.GetExistingMaps();
                    
            _existingMaps = new string[existingMaps.Length + 1];
            _existingMaps[0] = "New Map";
            for (int i = 1; i < _existingMaps.Length; i++)
            {
                _existingMaps[i] = existingMaps[i - 1];
            }
            _existingMaps.Concat(existingMaps); 
        }
}
