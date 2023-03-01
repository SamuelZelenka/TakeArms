using TakeArms.Services;

namespace TakeArms.GameInput
{
    using TakeArms.Systems;
    using UnityEngine;
    public class MouseTargeting : MonoBehaviour
    {
        [SerializeField]
        private GameObject selectionObject;
    
        private Camera _mainCamera;
        private Vector3 _worldPosition;
        private Ray _screenToMouseRay;
        Vector3 hitpoint;

        private void Awake()
        {
            _mainCamera = Camera.main;
            InputManager.RegisterKey(InputKeyState.KeyDown, SpawnUnit, KeyCode.Space);
        }

        private void Update()
        {
            Vector2Int gridCoordinate;

            _screenToMouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition); 
        
            Physics.Raycast(_screenToMouseRay, out var hit);
            hitpoint = hit.point;
            NodeVisualizerSystem.UpdateMouseNodeVisualizer(GameBoard.GetBoardPosFromWorld(hit.point));
        }

        public void SpawnUnit()
        {
            GameUnitSystem.SpawnUnit(RepositoryService.UnitConfigRepository.GetItem("Assault") , GameBoard.GetBoardPosFromWorld(hitpoint));
        }
    }
}
