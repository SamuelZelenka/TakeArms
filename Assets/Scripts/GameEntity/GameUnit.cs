using Configurations;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public Vector2Int boardPosition;
    public UnitConfiguration unitConfig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameBoard.MoveGameUnit(this,boardPosition + Vector2Int.up);
            transform.position = GameBoard.GetWorldPosFromBoardPos(boardPosition);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameBoard.MoveGameUnit(this,boardPosition + Vector2Int.down);
            transform.position = GameBoard.GetWorldPosFromBoardPos(boardPosition);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameBoard.MoveGameUnit(this,boardPosition + Vector2Int.right);
            transform.position = GameBoard.GetWorldPosFromBoardPos(boardPosition);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameBoard.MoveGameUnit(this,boardPosition + Vector2Int.left);
            transform.position = GameBoard.GetWorldPosFromBoardPos(boardPosition);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(GameBoard.GetWorldPosFromBoardPos(boardPosition), 0.2f);
    }
}
