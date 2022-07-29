using System;

namespace TakeArms.GameData
{
    [Serializable]
    public class GameState
    {
        public PlayerData[] players;
        public int playerTurn;
        public int startingPlayer;
    }
}
