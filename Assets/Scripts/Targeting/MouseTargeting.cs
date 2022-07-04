using UnityEngine;

public class MouseTargeting : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionObject;
    
    private Camera mainCamera;
    private Vector3 worldPosition;
    private Ray ray;
    private Terrain groundTerrain;
    private TerrainCollider groundTerrainCollider;

    private void Awake()
    {
        mainCamera = Camera.main;
        groundTerrain = Terrain.activeTerrains[0];
        groundTerrainCollider = groundTerrain.GetComponent<TerrainCollider>();
    }

    private void Update()
    {
        Vector2Int gridCoordinate;
        RaycastHit hit;

        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (groundTerrainCollider.Raycast(ray, out hit, Mathf.Infinity))
            worldPosition = hit.point;
        
        gridCoordinate = GetNodeAtWorldPos(worldPosition);
        
        float xPos = gridCoordinate.x;
        float yPos = groundTerrain.SampleHeight(worldPosition);
        float zPos = gridCoordinate.y;
        
        selectionObject.transform.position = new Vector3(xPos,yPos ,zPos);
    }
    void OnGUI()
    {
        GUILayout.Label(worldPosition.ToString());
    }

    public Vector2Int GetNodeAtWorldPos(Vector3 worldPos)
    {
        int xPos = Mathf.RoundToInt(worldPos.x);
        int yPos = Mathf.RoundToInt(worldPos.z);
        return new Vector2Int(xPos, yPos);
    }
}
