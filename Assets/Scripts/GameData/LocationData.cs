using System;

[Serializable]
public class LocationData
{
    private bool isPlayerBoard = false;
    private bool hasVictoryPoint = false;
    private int playerID = -1; // -1 unowned
    private UnitData[,] grid;
}