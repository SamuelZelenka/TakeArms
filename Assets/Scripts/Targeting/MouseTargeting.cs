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

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector2Int gridCoordinate;

            _screenToMouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition); 
        
            Physics.Raycast(_screenToMouseRay, out var hit);
        
            NodeVisualizerSystem.UpdateMouseNodeVisualizer(GameBoard.GetBoardPosFromWorld(hit.point));
        }
    }
}
