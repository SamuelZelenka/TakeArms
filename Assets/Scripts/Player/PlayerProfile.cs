using System;
using System.Collections.Generic;
using TakeArms.GameUnits;
using UnityEngine;
using Sirenix.Serialization;

namespace TakeArms.Player
{
    public enum PlayerColor { Red, Green, Blue, Yellow }

    public class PlayerProfile
    {
        public PlayerColor color;
        PlayerStatus status;

        public PlayerProfile(PlayerColor teamColor)
        {
            color = teamColor;
        }
        public Color GetColor()
        {
            switch (color)
            {
                case PlayerColor.Red:
                    return Color.red;

                case PlayerColor.Green:
                    return Color.green;

                case PlayerColor.Blue:
                    return Color.blue;

                case PlayerColor.Yellow:
                    return Color.yellow;

                default:
                    return Color.white;
            }
        }
    }

    [Serializable]
    public struct PlayerStatus
    {
        private int _money;
        private GameUnitStatus[] _gameUnits;
    }
}
