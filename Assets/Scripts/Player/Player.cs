using System;
using System.Collections.Generic;
using TakeArms.GameUnits;
using UnityEngine;

namespace TakeArms.Player
{
    public enum PlayerColor { Red, Green, Blue, Yellow }
    [Serializable]
    public class PlayerStatus
    {
        PlayerColor color;
        GameUnitStatus[] GameUnits;
    }
}
