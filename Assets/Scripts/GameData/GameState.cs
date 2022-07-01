using System;

[Serializable]
public class GameState
{
    public PlayerData[] players;
    public int playerTurn;
    public int startingPlayer;
    public LocationData[,] tileLayout = new LocationData[5,5];
}
