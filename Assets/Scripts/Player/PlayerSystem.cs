using Sirenix.Serialization;
using System.Collections;
using TakeArms.Player;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [OdinSerialize]
    public PlayerProfile[] players;
    public int PlayerCount { get; private set; }

    public void SetPlayers(PlayerProfile[] players)
    {
        this.players = players;
        PlayerCount = players.Length;
    }
}
