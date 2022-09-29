using System.Collections;
using System.Collections.Generic;
using TakeArms.Player;
using UnityEngine;

public class LobbyClientUI : MonoBehaviour
{
    [SerializeField] private ulong _clientID;

    public void SetClientID(ulong clientID)
    {
        _clientID = clientID;
    }
}
