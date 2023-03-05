using System.Collections;
using System.Collections.Generic;
using TakeArms.GameData;
using TakeArms.Services;
using TakeArms.Systems;
using UnityEngine;

public abstract class TargetingConfiguration
{
    protected bool isTargeting;
    public abstract UnitData[] GetTargetNodes();
    public abstract bool IsValidTarget(Vector2Int nodePosition);
    public virtual void StartTargeting()
    {
        isTargeting = true;
    }
    public virtual void StopTargeting()
    {
        isTargeting = false;
    }
}

public class UnitTargeting : TargetingConfiguration
{
    public override UnitData[] GetTargetNodes()
    {
        if (isTargeting)
        {
            Vector3 screenPos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            Vector2Int boardPos = GameBoard.GetBoardPosFromWorld(worldPos);

            if (IsValidTarget(boardPos))
            {
                // return GameSystemService.GameBoard.gameUnits[];
            }
        }
        return null;
    }

    public override bool IsValidTarget(Vector2Int nodePosition)
    {
        return true;
    }
}
