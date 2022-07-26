using UnityEngine;

public class MouseTargeting : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionObject;
    
    private Camera mainCamera;
    private Vector3 worldPosition;
    private Ray screenToMouseRay;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2Int gridCoordinate;
        RaycastHit hit;

        screenToMouseRay = mainCamera.ScreenPointToRay(Input.mousePosition); 
        worldPosition = GameBoard.Instance.GetTerrainPosFromRay(screenToMouseRay);
        
        gridCoordinate = GetNodeAtWorldPos(worldPosition);
        
        float xPos = gridCoordinate.x;
        float yPos = GameBoard.Instance.GetTerrainHeightFromPosition(worldPosition);
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
