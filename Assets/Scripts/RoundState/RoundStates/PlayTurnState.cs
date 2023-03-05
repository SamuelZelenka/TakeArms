using TakeArms.Services;

namespace TakeArms.Systems
{
    public class PlayTurnState : RoundState
    {
        public override void Start()
        {
            base.Start();
            GameSystemService.TurnSystem.ShowCurrentPlayer(true);
        }
        public override void Update()
        {

        }

        public override void End()
        {
            base.End();
            GameSystemService.TurnSystem.ShowCurrentPlayer(false);
        }

        public override RoundState GetNextRoundState() => new EndTurnState();
    }
}
