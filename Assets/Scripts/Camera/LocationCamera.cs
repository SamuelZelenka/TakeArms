using UnityEngine;

namespace TakeArms.Camera
{
   public class LocationCamera : MonoBehaviour
    {
        [SerializeField]
        private float _cameraSpeed = 0.1f;

        [SerializeField]
        private float _cameraZoomSpeed = 1f;

        [SerializeField]
        private float _minSize;

        [SerializeField]
        private float _maxSize;

        private Vector3 _lastClickedPos;
        private Vector3 _targetLocation;
   
        private float _clickTime;

        private UnityEngine.Camera _camera;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
            InputManager.RegisterAxis("Mouse ScrollWheel", (output) => ZoomOut(), new AxisCondition(0, LogicCondition.GreaterThan));
            InputManager.RegisterAxis("Mouse ScrollWheel", (output) => ZoomIn(), new AxisCondition(0, LogicCondition.LessThan));
            InputManager.RegisterKey(InputKeyState.KeyDown, SetLastClickPos, KeyCode.Mouse2);
            InputManager.RegisterKey(InputKeyState.KeyHold, DragMouse, KeyCode.Mouse2);

        }

        private void Update()
        {
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minSize, _maxSize);
        }
        private void SetLastClickPos()
        {
            _lastClickedPos = Input.mousePosition;
            _clickTime = Time.time;
        }
        private void DragMouse() => MoveTowardsTarget();

        private void ZoomOut() => _camera.orthographicSize = Mathf.Max(_minSize, _camera.orthographicSize - _cameraZoomSpeed * Time.deltaTime);

        private void ZoomIn() => _camera.orthographicSize = Mathf.Min(_maxSize, _camera.orthographicSize + _cameraZoomSpeed * Time.deltaTime);

        private void MoveTowardsTarget()
        {
            _targetLocation = GetDirection();
            float distCovered = (Time.time - _clickTime);
            float distToTarget = Vector3.Distance(transform.position, _targetLocation);
            if (distToTarget != 0)
            {
                float fractionCovered = distCovered / distToTarget;
                transform.position = Vector3.Lerp(transform.position, _targetLocation, fractionCovered);
            }
        }

        private Vector3 GetDirection()
        {
            Vector3 dragDirection = Input.mousePosition - _lastClickedPos;
            float dragMagnitude = dragDirection.magnitude;
            dragDirection.Normalize();

            Quaternion rotation = Quaternion.Euler(0, 0, -45);
            dragDirection = rotation * dragDirection;

            return transform.position + new Vector3(dragDirection.x, 0f, dragDirection.y) * dragMagnitude * _cameraSpeed * Time.deltaTime;
        }
    }
}
