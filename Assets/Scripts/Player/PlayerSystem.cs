using Sirenix.Serialization;
using System.Collections.Generic;
using TakeArms.Player;
using UnityEngine;
using Unity.Netcode;


public class PlayerSystem
{
    public delegate void PlayerHandler(ulong clientID);
    public PlayerHandler OnPlayerAdded;
    public PlayerHandler OnPlayerRemoved;

    [OdinSerialize]
    public Dictionary<ulong, PlayerController> players = new Dictionary<ulong, PlayerController>();
    public int PlayerCount { get; private set; }

    public void AddPlayer(PlayerController controller)
    {
        players.Add(controller.NetworkObjectId, controller);
        OnPlayerAdded?.Invoke(controller.NetworkObjectId);
    }

    public void RemovePlayer(ulong clientID)
    {
        players.Remove(clientID);
        OnPlayerRemoved?.Invoke(clientID);
    }
}
