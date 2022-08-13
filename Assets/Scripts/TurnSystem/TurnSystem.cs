using System;
using TakeArms.Systems;
using TakeArms.Utility;
using UnityEngine;

namespace TakeArms.Systems
{
    public class TurnSystem : MonoBehaviour
    {
        public delegate void TurnHandler();

        public TurnHandler OnTurnStarted;
        public TurnHandler OnTurnEnded;

        private RoundState roundState;

        private int currentRound = 0;

        private int _startingPlayer = 0;
        private int _currentPlayer = 0;
        private int _playerCount = 2;

        private void Start()
        {
            roundState = new CardPickState();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextRoundState();
            }
            roundState.Update();
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5,5, 200,100 ), "State: " + roundState.GetType());
            // GUI.Label(new Rect(5,105, 200,100 ), _startingPlayer.ToString());
            // GUI.Label(new Rect(5,210, 200,100 ), roundState.ToString());
        }

        public RoundState GetCurrentRoundState()
        {
            return roundState;
        }
        
        public void SetStartingPlayer(int player)
        {
            _startingPlayer = player;
        }

        public void NextPlayerTurn()
        {
            _currentPlayer = MathUtility.WrapModulo(_currentPlayer + 1, _playerCount);
        }

        private void NextRoundState()
        {
            roundState = roundState.GetNextRoundState();
        }


    } 
}

