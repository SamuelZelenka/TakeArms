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

        private Vector2 _lastClickedPos;
        private float _screenMoveXDirecion;
        private float _screenMoveYDirecion;

        private Vector3 _targetLocation;
   
        private float _clickTime;

        private UnityEngine.Camera _camera;


        private InputKey _mouseDownInput;
        private InputKey _mouseDragInput;

        private InputAxis _mouseScroll;

        private InputDualAxis _keyMoveAxis;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;

            _mouseDownInput = new InputKey(KeyCode.Mouse2, InputKeyState.KeyDown, SetLastClickPos);
            _mouseDragInput = new InputKey(KeyCode.Mouse2, InputKeyState.KeyHold, DragMouse);
            _keyMoveAxis = new InputDualAxis("Horizontal", "Vertical", KeyMovement);
            _mouseScroll = new InputAxis("Mouse ScrollWheel", (output) => Zoom(output), new AxisCondition(0, LogicCondition.NotEqual));

            InputManager.RegisterKey(InputGroup.Playing, _mouseDownInput);
            InputManager.RegisterKey(InputGroup.Playing, _mouseDragInput);

            InputManager.RegisterAxis(InputGroup.Playing, _mouseScroll);

            InputManager.RegisterDualAxis(InputGroup.Playing, _keyMoveAxis);
        }

        private void SetLastClickPos()
        {
            _lastClickedPos = Input.mousePosition;
            _clickTime = Time.time;
        }

        private void KeyMovement(Vector2 axisOutput)
        {
            MoveTowardsTarget(axisOutput.normalized);
        }


        private void DragMouse()
        {
            Vector2 mouseDir = ((Vector2)Input.mousePosition - _lastClickedPos) / 100;
            MoveTowardsTarget(mouseDir);
        }
        private void Zoom(float value)
        {
            _camera.orthographicSize = Mathf.Min(_maxSize, _camera.orthographicSize - value * _cameraZoomSpeed * Time.deltaTime);
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minSize, _maxSize);
        }

        private void MoveTowardsTarget(Vector2 screenPos)
        {
            _targetLocation = GetDirection(screenPos);
            float distCovered = (Time.time - _clickTime);
            float distToTarget = Vector3.Distance(transform.position, _targetLocation);
            if (distToTarget != 0)
            {
                float fractionCovered = distCovered / distToTarget;
                transform.position = Vector3.Lerp(transform.position, _targetLocation, fractionCovered);
            }
        }

        private Vector3 GetDirection(Vector2 screenDir)
        {
            float dragMagnitude = screenDir.magnitude;
            screenDir.Normalize();

            Quaternion rotation = Quaternion.Euler(0, 0, -45);
            screenDir = rotation * screenDir;

            return transform.position + new Vector3(screenDir.x, 0f, screenDir.y) * dragMagnitude * _cameraSpeed * Time.deltaTime;
        }
    }
}
