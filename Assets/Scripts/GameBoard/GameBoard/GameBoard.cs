using TakeArms.Services;
using TakeArms.GameUnits;
using System.Collections.Generic;
using UnityEngine;

namespace TakeArms.Systems
{
    public class GameBoard : MonoBehaviour
    {
        public Dictionary<Vector2Int, GameUnit> gameUnits = new Dictionary<Vector2Int, GameUnit>();

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

            var terrain = FindObjectOfType<Terrain>();

            var newPos = new Vector3(worldPosX, 0, worldPosY);
            newPos.y = terrain.SampleHeight(newPos);

            return newPos;
        }

        public static Vector2Int GetBoardPosFromWorld(Vector3 worldPos)
        {
            int boardPosX = Mathf.RoundToInt(worldPos.x);
            int boardPosY = Mathf.RoundToInt(worldPos.z);

            return new Vector2Int(boardPosX, boardPosY);
        }

        public static void MoveGameUnit(GameUnit unit, Vector2Int newPosition)
        {
            //GameUnit unitToMove = GameSystemService.GameBoard.gameUnits[unit];
            //unitToMove.unitStatus.boardPosition = newPosition;
        }
    }
}
