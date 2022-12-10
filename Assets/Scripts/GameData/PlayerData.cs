using System;
using TakeArms.Services;

namespace TakeArms.GameData
{
    [Serializable]
    public class PlayerData
    {
        public readonly int playerID;
        public int playerClassID;
        public int[] deck;
        public int money;
        public int victoryPoints;
        public SoldierData[] soldiers;
        public BuildingData[] buildings;

        public PlayerData(int playerID)
        {
            this.playerID = playerID;
        }

        public PlayerData(PlayerData data, int playerID)
        {
            this.playerID = playerID;
            playerClassID = data.playerClassID;
            deck = data.deck;
            money = data.money;
            victoryPoints = data.victoryPoints;
            soldiers = data.soldiers;
            buildings = data.buildings;
        }

    }
}