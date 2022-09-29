using System.Collections;
using System.Collections.Generic;
using TakeArms.Player;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUi : MonoBehaviour
{
    [SerializeField] private LobbyClientUI _clientUIPrefab;

    [SerializeField] private Text _playerCountText;
    [SerializeField] private GameObject _lobbyParent;

    private int maxPlayerCount;
    private int playerCount => _players.Count;
    private List<LobbyClientUI> _players;

    private void OnEnable()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += AddPlayer;
        NetworkManager.Singleton.OnClientDisconnectCallback += RemovePlayer;
    }
    private void OnDisable()
    {
        NetworkManager.Singleton.OnClientConnectedCallback -= AddPlayer;
        NetworkManager.Singleton.OnClientDisconnectCallback -= RemovePlayer;

    }

    private void AddPlayer(ulong clientID)
    {

    }

    private void RemovePlayer(ulong clientID)
    {

    }
}


