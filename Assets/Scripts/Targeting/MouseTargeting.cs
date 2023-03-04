using TakeArms.Services;

namespace TakeArms.GameInput
{
    using TakeArms.Systems;
    using UnityEngine;
    public class MouseTargeting : MonoBehaviour
    {    
        private Camera _mainCamera;
        private Ray _screenToMouseRay;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2Int gridCoordinate;
            NodeVisualizerSystem.UpdateMouseNodeVisualizer(GameBoard.GetBoardPosFromWorld(GetMouseWorldPos()));
        }

        public Vector3 GetMouseWorldPos()
        {
            _screenToMouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(_screenToMouseRay, out var hit);
            return hit.point;
        }

        public Vector2Int GetMouseCoordinate()
        {
            var mousePos = GetMouseWorldPos();
            return GameBoard.GetBoardPosFromWorld(mousePos);
        }
    }
}
