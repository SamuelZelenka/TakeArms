using TakeArms.Configurations;
using TakeArms.GameUnits;
using TakeArms.Services;
using UnityEngine;

public class GameUnitFactory
{
    public static GameUnit CreatePlayerUnit(int unitConfigID, GameUnitStatus unitStatus, int playerID)
    {
        UnitConfiguration newConfig = RepositoryService.UnitConfigRepository.GetItem(unitConfigID);

        GameUnit newUnit = new GameObject().AddComponent<GameUnit>();
        newUnit.unitConfig = newConfig;
        newUnit.unitStatus = new GameUnitStatus();
        newUnit.unitStatus.boardPosition = default;
        newUnit.unitStatus.health = GameUnitStatus.UnitHealth.Alive;
        newUnit.unitConfig.InitObject(newUnit.transform);
        return newUnit;
    }
}
