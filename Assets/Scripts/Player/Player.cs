using TakeArms.GameData;
using TakeArms.Services;
using UnityEngine;

// This is the instance of the individual player
public class Player : MonoBehaviour
{
    private int playerID;
    private bool aiControlled;

    public int PlayerID => playerID;

    public void Init(int id)
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
