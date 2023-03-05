namespace TakeArms.Systems
{
    public class EndTurnState : RoundState
    {
        public override void Update()
        {
            
        }

        public override RoundState GetNextRoundState() => new CardPickState();
    }
}
