using Sirenix.Serialization;
using System.Collections.Generic;
using TakeArms.GameData;
using TakeArms.Gameplay;
using TakeArms.Services;
using UnityEngine;

namespace TakeArms.Systems
{
    public class PlayerSystem
    {
        public delegate void PlayerHandler(Player clientID);
        public PlayerHandler OnPlayerAdded;
        public PlayerHandler OnPlayerRemoved;

        [OdinSerialize]
        public Dictionary<ulong, PlayerData> players = new Dictionary<ulong, PlayerData>();
        public int PlayerCount { get; private set; }

        public void AddPlayer()
        {
            Player player = new GameObject().AddComponent<Player>();
            player.transform.SetParent(GetPlayerParent());
            player.Init(RepositoryService.GetUniqueID(players));
            player.name = "Player " + player.PlayerID;
            players.Add(player.PlayerID, new PlayerData(player.PlayerID));
            OnPlayerAdded?.Invoke(player);
        }

        public void RemovePlayer(ulong playerID)
        {
            players.Remove(playerID);
            foreach (Transform child in GetPlayerParent())
            {
                Player player = child.GetComponent<Player>();
                if (player?.PlayerID == playerID)
                {
                    OnPlayerRemoved?.Invoke(player);
                }
            }
        }

        private Transform GetPlayerParent()
        {
            const string PLAYER_PARENT_NAME = "Players";

            foreach (Transform child in GameSystemService.GameBoard.transform)
                if (child.name == PLAYER_PARENT_NAME)
                    return child;

            var playersParent = new GameObject(PLAYER_PARENT_NAME);
            playersParent.transform.SetParent(GameSystemService.GameBoard.transform);
            return playersParent.transform;
        }
    }
}
