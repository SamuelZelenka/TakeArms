using TakeArms.Configurations;
using TakeArms.Services;
using TakeArms.Systems;

using UnityEngine;

namespace TakeArms.GameUnits
{
    public class GameUnit : MonoBehaviour
    {
        public GameUnitStatus unitStatus;
        public UnitConfiguration unitConfig;

        void Update()
        {
            if (GameSystemService.TurnSystem.GetCurrentRoundState().GetType() == typeof(PlayTurnState))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    GameBoard.MoveGameUnit(this, unitStatus.boardPosition + Vector2Int.up);
                    transform.position = GameBoard.GetWorldPosFromBoardPos(unitStatus.boardPosition);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    GameBoard.MoveGameUnit(this, unitStatus.boardPosition + Vector2Int.down);
                    transform.position = GameBoard.GetWorldPosFromBoardPos(unitStatus.boardPosition);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    GameBoard.MoveGameUnit(this, unitStatus.boardPosition + Vector2Int.right);
                    transform.position = GameBoard.GetWorldPosFromBoardPos(unitStatus.boardPosition);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    GameBoard.MoveGameUnit(this, unitStatus.boardPosition + Vector2Int.left);
                    transform.position = GameBoard.GetWorldPosFromBoardPos(unitStatus.boardPosition);
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
        }
    }
}

