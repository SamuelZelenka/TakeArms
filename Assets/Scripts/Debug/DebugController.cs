using TakeArms.Services;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public static void NextTurn() => GameSystemService.TurnSystem.NextPlayerTurn();
    public static void AddPlayer() => GameSystemService.PlayerSystem.AddPlayer();
    public static void RemovePlayer(ulong id) => GameSystemService.PlayerSystem.RemovePlayer(id);
}
