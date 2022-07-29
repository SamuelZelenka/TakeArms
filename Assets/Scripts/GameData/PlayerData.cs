using System;

namespace TakeArms.GameData
{
    [Serializable]
    public class PlayerData
    {
        public int playerID;
        public int playerClassID;
        public int[] deck;
        public int money;
        public int victoryPoints;
        public SoldierData[] soldiers;
        public BuildingData[] buildings;
    }
}