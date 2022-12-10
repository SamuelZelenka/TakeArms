using TakeArms.Configurations;
using TakeArms.Services;
using TakeArms.GameUnits;
using System.Collections.Generic;
using UnityEngine;

namespace TakeArms.Systems
{
    public class GameBoard : MonoBehaviour
    {
        public List<GameUnit> gameUnits = new List<GameUnit>();

        private void Start()
        {
            if (GameSystemService.GameBoard != null && GameSystemService.GameBoard != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        public static Vector3 GetWorldPosFromBoardPos(Vector2Int boardPos)
        {
            float worldPosX = boardPos.x;
            float worldPosY = boardPos.y;

            return new Vector3(worldPosX, worldPosY, 0);
        }

        public static void MoveGameUnit(GameUnit unit, Vector2Int newPosition)
        {
            GameUnit unitToMove = GameSystemService.GameBoard.gameUnits.Find(x => x == unit);
            unitToMove.unitStatus.boardPosition = newPosition;
        }

        public static void AddPlayer()
        {
            GameSystemService.PlayerSystem.AddPlayer();
        }
        public static void RemovePlayer(int id)
        {
            GameSystemService.PlayerSystem.RemovePlayer(id);
        }
    }
}

