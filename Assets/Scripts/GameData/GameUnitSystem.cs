using System.Collections;
using System.Collections.Generic;
using TakeArms.GameUnits;
using TakeArms.GameData;
using UnityEngine;

public class GameUnitSystem
{
    private static Dictionary<string, GameUnitStatus> _gameUnits = new Dictionary<string, GameUnitStatus>();

    public static void MoveUnit(int id)
    {

    }

    public static void AddUnit(UnitData data)
    {
     
    }

    public static string GetGameUnitAt(Vector2Int coordinate)
    {
        foreach (var unit in _gameUnits)
        {
            if (unit.Value.boardPosition == coordinate)
            {
                return unit.Key;
            }
        }
        return null;
    }

}
