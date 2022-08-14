using TakeArms.Configurations;
using TakeArms.Services;
using TakeArms.GameUnits;
using TakeArms.Player;
using System.Collections.Generic;
using UnityEngine;

namespace TakeArms.Systems
{
    public class GameBoard : MonoBehaviour
    {
        public List<GameUnit> gameUnits = new List<GameUnit>();
    
        private Terrain _groundTerrain;
        private TerrainCollider _groundTerrainCollider;
        
        private void Start()
        {
            if (GameSystemService.GameBoard != null && GameSystemService.GameBoard != this)
            {
                Destroy(gameObject);
                return;
            }

            //REMOVE TEMP UNIT AT SOME POINT
            GameUnit newUnit = GameUnitFactory.CreatePlayerUnit(0, new GameUnitStatus(), PlayerColor.Red);
            gameUnits.Add(newUnit);
            //REMOVE TEMP UNIT AT SOME POINT
            
            _groundTerrain = Terrain.activeTerrains[0];
            _groundTerrainCollider = _groundTerrain.GetComponent<TerrainCollider>();
        }
    
        public Vector3 GetTerrainPosFromRay(Ray ray)
        {
            _groundTerrainCollider.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
            return hit.point;
        }
        
        public float GetTerrainHeightFromPosition(Vector3 worldPosition)
        {
            return _groundTerrain.SampleHeight(worldPosition);
        }
    
        public static Vector3 GetWorldPosFromBoardPos(Vector2Int boardPos)
        {
            float worldPosX = boardPos.x;
            float worldPosZ = boardPos.y;
            float worldPosY = GameSystemService.GameBoard.GetTerrainHeightFromPosition(new Vector3(worldPosX,0,worldPosZ));
            return new Vector3(worldPosX, worldPosY, worldPosZ);
        }
    
        public static void MoveGameUnit(GameUnit unit, Vector2Int newPosition)
        {
            GameUnit unitToMove = GameSystemService.GameBoard.gameUnits.Find(x => x == unit);
            unitToMove.unitStatus.boardPosition = newPosition;
        }
    }
}

