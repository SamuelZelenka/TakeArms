using System;
using System.Collections.Generic;
using TakeArms.GameUnits;
using UnityEngine;

namespace TakeArms.Player
{
    public enum PlayerColor { Red, Green, Blue, Yellow }


    public class PlayerProfile
    {
        PlayerColor color;
        PlayerStatus status;
    }

    [Serializable]
    public struct PlayerStatus
    {
        private int _money;
        private GameUnitStatus[] _gameUnits;
    }
}
