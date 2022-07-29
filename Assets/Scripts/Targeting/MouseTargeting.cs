using TakeArms.Services;

namespace TakeArms.GameInput
{
    using UnityEngine;
    public class MouseTargeting : MonoBehaviour
    {
        [SerializeField]
        private GameObject selectionObject;
    
        private Camera _mainCamera;
        private Vector3 _worldPosition;
        private Ray _screenToMouseRay;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2Int gridCoordinate;

            _screenToMouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition); 
            _worldPosition = GameSystemService.GameBoard.GetTerrainPosFromRay(_screenToMouseRay);
        
            gridCoordinate = GetNodeAtWorldPos(_worldPosition);
        
            float xPos = gridCoordinate.x;
            float yPos = GameSystemService.GameBoard.GetTerrainHeightFromPosition(_worldPosition);
            float zPos = gridCoordinate.y;
        
            selectionObject.transform.position = new Vector3(xPos,yPos ,zPos);
        }

        public Vector2Int GetNodeAtWorldPos(Vector3 worldPos)
        {
            int xPos = Mathf.RoundToInt(worldPos.x);
            int yPos = Mathf.RoundToInt(worldPos.z);
            return new Vector2Int(xPos, yPos);
        }
    }
}
