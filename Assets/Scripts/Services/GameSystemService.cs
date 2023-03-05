using TakeArms.Systems;
using UnityEngine;

namespace TakeArms.Services
{
    public static class GameSystemService
    {
        //Singletons
        private static GameBoard _gameBoard;
        public static GameBoard GameBoard => _gameBoard == null ? _gameBoard = GetSingleton<GameBoard>() : _gameBoard;

        private static GameUISystem _gameUISystem;
        public static GameUISystem GameUISystem => _gameUISystem == null ? _gameUISystem = GetSingleton<GameUISystem>() : _gameUISystem;

        private static TurnSystem _turnSystem;
        public static TurnSystem TurnSystem => _turnSystem == null ? _turnSystem = new TurnSystem() : _turnSystem;

        private static PlayerSystem _playerSystem;
        public static PlayerSystem PlayerSystem => _playerSystem == null ? _playerSystem = new PlayerSystem() : _playerSystem;

        private static RoundStateSystem _roundStateSystem;
        public static RoundStateSystem RoundStateSystem => _roundStateSystem == null ? _roundStateSystem = new RoundStateSystem() : _roundStateSystem;

        private static T GetSingleton<T>() where T : MonoBehaviour
        {
            T foundInstance = GameObject.FindObjectOfType<T>();
            Debug.Assert(foundInstance, $"There is no instance of <{typeof(T)}> in the scene.");
            return foundInstance;
        }
    }
}
