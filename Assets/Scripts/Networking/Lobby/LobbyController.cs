using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    public delegate void LobbyHandler(NetworkClient clientID);
    public LobbyHandler OnClientConnect;
    public LobbyHandler OnClientDisconnect;
    public LobbyHandler OnClientUpdate;
    private void Awake()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += ClientConnected;
    }
    public void ClientConnected(ulong playerID)
    {
        OnClientConnect.Invoke(NetworkManager.Singleton.ConnectedClients[playerID]);
    }
}
