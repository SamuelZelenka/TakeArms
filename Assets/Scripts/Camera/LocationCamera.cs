using TakeArms.GameInput;
using UnityEngine;

namespace TakeArms.Camera
{
   public class LocationCamera : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 0.1f;
        [SerializeField] private float _cameraZoomSpeed = 1f;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;

        private UnityEngine.Camera _camera;

        private InputKey _mouseDownInput;
        private InputKey _mouseDragInput;
        private InputAxis _mouseScroll;
        private InputDualAxis _keyMoveAxis;

        private float _clickTime;
        private Vector2 _lastClickedPos;
        private Vector3 _targetLocation;

        private void Start()
        {
            // Get the main camera
            _camera = UnityEngine.Camera.main;

            // Set up input keys and axis
            _mouseDownInput = new InputKey(KeyCode.Mouse2, InputKeyState.KeyDown, SetLastClickPos);
            _mouseDragInput = new InputKey(KeyCode.Mouse2, InputKeyState.KeyHold, MouseMovement);
            _keyMoveAxis = new InputDualAxis("Horizontal", "Vertical", KeyMovement);
            _mouseScroll = new InputAxis("Mouse ScrollWheel", (output) => Zoom(output), new AxisCondition(0, LogicCondition.NotEqual));

            // Register the input keys and axis with the InputManager
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

        private void KeyMovement(Vector2 axisOutput) => MoveTowardsTarget(axisOutput);

        private void MouseMovement() => MoveTowardsTarget(((Vector2)Input.mousePosition - _lastClickedPos) / 100);

        private void Zoom(float value) => _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - value * _cameraZoomSpeed * Time.deltaTime, _minSize, _maxSize);

        private void MoveTowardsTarget(Vector2 direction)
        {
            _targetLocation = GetTargetLocation(direction);

            float distCovered = (Time.time - _clickTime);
            float distToTarget = Vector3.Distance(transform.position, _targetLocation);

            if (distToTarget == 0)
                return;

            float fractionCovered = distCovered / distToTarget;

            transform.position = Vector3.Lerp(transform.position, _targetLocation, fractionCovered);
        }

        private Vector3 GetTargetLocation(Vector2 screenDir)
        {
            float dragMagnitude = screenDir.magnitude;
            screenDir.Normalize();

            Quaternion rotation = Quaternion.Euler(0, 0, -45);
            screenDir = rotation * screenDir;
            Vector3 targetLocation = new Vector3(screenDir.x, 0f, screenDir.y) * dragMagnitude * _cameraSpeed * Time.deltaTime;
            return transform.position + targetLocation;
        }
    }
}
