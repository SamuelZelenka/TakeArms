using TakeArms.Utility;
using TakeArms.Player;
using UnityEngine;
using TakeArms.Services;

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

        public int StartingPlayer => _startingPlayer;
        public int CurrentPlayer => _currentPlayer;

        public bool showCurrentPlayerDebug = false;

        private void Start()
        {
            roundState = new CardPickState();

            PlayerProfile[] newPlayers = { new PlayerProfile(PlayerColor.Red), new PlayerProfile(PlayerColor.Green) };
            GameSystemService.PlayerSystem.SetPlayers(newPlayers);
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
            GUI.Label(new Rect(5,5, 500,100 ), "State: " + roundState.GetType());
            if (showCurrentPlayerDebug)
            {
                Color previousColor = GUI.color;
                GUI.color = GameSystemService.PlayerSystem.players[_currentPlayer].GetColor();
                GUI.Label(new Rect(5, 25, 500, 100), "Current Player: " + GameSystemService.PlayerSystem.players[_currentPlayer].color.ToString());
                GUI.color = previousColor;
            }
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
            _currentPlayer = MathUtility.WrapModulo(_currentPlayer + 1, GameSystemService.PlayerSystem.PlayerCount);
        }

        private void NextRoundState()
        {
            roundState.End();
            roundState = roundState.GetNextRoundState();
            roundState.Start();
        }
        public void ShowCurrentPlayer(bool isShowing)
        {
            showCurrentPlayerDebug = isShowing;
        }
    }
}

