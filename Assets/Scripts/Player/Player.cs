using TakeArms.GameData;
using TakeArms.Services;
using UnityEngine;

// This is the instance of the individual player
public class Player : MonoBehaviour
{
    private ulong playerID;
    private bool aiControlled;

    public ulong PlayerID => playerID;

    public void Init(ulong id)
    {
        playerID = id;
        GameSystemService.GameUISystem.AddPlayerUI(playerID);
        GameSystemService.PlayerSystem.OnPlayerRemoved += RemovePlayer;
    }

    private void RemovePlayer(Player player)
    {
        if (player == this) 
            Destroy(gameObject);
    }
}
