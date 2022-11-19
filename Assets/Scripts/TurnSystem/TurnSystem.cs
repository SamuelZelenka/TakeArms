using TakeArms.Utility;
using UnityEngine;
using TakeArms.Services;

namespace TakeArms.Systems
{
    public class TurnSystem
    {
        public delegate void TurnHandler();

        public TurnHandler OnTurnStarted;
        public TurnHandler OnTurnEnded;

        private int currentRound = 0;

        private int _startingPlayer = 0;
        private int _currentPlayer = 0;

        public int StartingPlayer => _startingPlayer;
        public int CurrentPlayer => _currentPlayer;

        public bool showCurrentPlayerDebug = false;

        private void OnGUI()
        {
            if (showCurrentPlayerDebug)
            {
                Color previousColor = GUI.color;
                GUI.color = previousColor;
            }
        }

        public void SetStartingPlayer(int player)
        {
            _startingPlayer = player;
        }

        public void NextPlayerTurn()
        {
            _currentPlayer = MathUtility.WrapModulo(_currentPlayer + 1, GameSystemService.PlayerSystem.PlayerCount);
        }

        public void ShowCurrentPlayer(bool isShowing)
        {
            showCurrentPlayerDebug = isShowing;
        }
    }
}

