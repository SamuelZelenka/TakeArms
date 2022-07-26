using System;

[Serializable]
public class GameState
{
    public PlayerData[] players;
    public int playerTurn;
    public int startingPlayer;
}
