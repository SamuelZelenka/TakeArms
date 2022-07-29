using UnityEngine;

namespace TakeArms.Camera
{
   public class LocationCamera : MonoBehaviour
   {
       private float _cameraSpeed = 0.1f;
       
       private Vector3 _lastClickedPos;
       private Vector3 _targetLocation;
   
       private float _clickTime;
   
       private void Update()
       {
           if (Input.GetAxis("Mouse ScrollWheel") > 0)
           {
               transform.position += transform.forward;
           }
   
           if (Input.GetAxis("Mouse ScrollWheel") < 0)
           {
               transform.position += -transform.forward;
           }
           
           if (Input.GetMouseButtonDown(2))
           {
               _lastClickedPos = Input.mousePosition;
               _clickTime = Time.time;
           }
           
           // TODO: Smooth lerp on button release
           
           if (Input.GetMouseButton(2))
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
