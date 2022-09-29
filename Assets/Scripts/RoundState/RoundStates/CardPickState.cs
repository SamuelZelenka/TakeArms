using TakeArms.Services;
using UnityEngine;

namespace TakeArms.Systems
{
    public class CardPickState : RoundState
    {
        int readyPlayer = 0;
        public override void Update()
        {
            bool allPlayersReady = true;
            foreach (var player in GameSystemService.PlayerSystem.players)
            {
                //if (!player.isReady)
                //{
                //    allPlayersReady = false;
                //    return;
                //}

                Debug.LogWarning("NOT CHECKING PLAYER IS READY");
            }

            GameSystemService.RoundStateSystem.NextRoundState();
        }

        public override RoundState GetNextRoundState() => new PlayOrderState();
    }
}