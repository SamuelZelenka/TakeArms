using Sirenix.Serialization;
using System.Collections.Generic;
using TakeArms.Player;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public delegate void PlayerHandler(ulong clientID);
    public PlayerHandler OnPlayerAdded;
    public PlayerHandler OnPlayerRemoved;

    [OdinSerialize]
    public Dictionary<ulong, PlayerProfile> players = new Dictionary<ulong, PlayerProfile>();
    public int PlayerCount { get; private set; }

    public void AddPlayer(ulong clientID)
    {
        var newPlayer = new PlayerProfile(clientID);
        players.Add(clientID, newPlayer);
        OnPlayerAdded?.Invoke(clientID);
    }

    public void RemovePlayer(ulong clientID)
    {
        players.Remove(clientID);
        OnPlayerRemoved?.Invoke(clientID);
    }
}
