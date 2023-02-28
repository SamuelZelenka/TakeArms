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

        }

        private void Update()
        {
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minSize, _maxSize);

            if (Input.GetMouseButtonDown(2))
            {
                _lastClickedPos = Input.mousePosition;
                _clickTime = Time.time;
            }

            // TODO: Smooth lerp on button release

            if (Input.GetMouseButton(2))
            {
                _targetLocation = GetDirection();
                MoveTowardsTarget();
            }
        }

        private void ZoomOut() => _camera.orthographicSize = Mathf.Max(_minSize, _camera.orthographicSize - _cameraZoomSpeed * Time.deltaTime);

        private void ZoomIn() => _camera.orthographicSize = Mathf.Min(_maxSize, _camera.orthographicSize + _cameraZoomSpeed * Time.deltaTime);

        private void MoveTowardsTarget()
        {
            
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
           Vector3 position = transform.position;
               
           float xPos = position.x;
           float yPos = position.y;
           float zPos = position.z;
   
           Vector3 dragDirection = Input.mousePosition - _lastClickedPos;
           float dragMagnitude = dragDirection.magnitude;
           dragDirection.Normalize();
   
           float newXDir = xPos + dragDirection.x * dragMagnitude * _cameraSpeed * Time.deltaTime;
           float newYDir = zPos + dragDirection.y * dragMagnitude * _cameraSpeed * Time.deltaTime;
           return new Vector3(newXDir, yPos, newYDir);
        }
   }
}
