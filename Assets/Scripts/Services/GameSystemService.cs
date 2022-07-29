using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameSystemService
    {
        //Singletons
        private static GameBoard _gameBoard;
        public static GameBoard GameBoard => _gameBoard == null ? _gameBoard = GetSingleton<GameBoard>() : _gameBoard;
        
        private static TurnSystem _turnSystem;
        public static TurnSystem TurnSystem => _turnSystem == null ? _turnSystem = GetSingleton<TurnSystem>() : _turnSystem;
        
        public static T GetSingleton<T>() where T : MonoBehaviour
        {
            T foundInstance = GameObject.FindObjectOfType<T>();
            Debug.Assert(foundInstance, $"There is no instance of <{typeof(T)}> in the scene.");
            return foundInstance;
        }
    }
}