using TakeArms.Services;

namespace TakeArms.Systems
{
    public class PlayOrderState : RoundState
    {
        public override void Start()
        {
            for (int i = 0; i < GameSystemService.PlayerSystem.PlayerCount; i++)
            {

            }
            base.Start();
        }

        public override void Update()
        {
            
        }
        public override RoundState GetNextRoundState() => new PlayTurnState();
    }
}
