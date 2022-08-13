namespace TakeArms.Systems
{
    public class CardPickState : RoundState
    {
        public override void Update()
        {
            
        }

        public override RoundState GetNextRoundState() => new PlayOrderState();
    }
    
    public class PlayOrderState : RoundState
    {
        public override void Update()
        {
            
        }

        public override RoundState GetNextRoundState() => new PlayTurnState();
    }
    
    public class PlayTurnState : RoundState
    {
        public override void Update()
        {
            
        }

        public override RoundState GetNextRoundState() => new EndTurnState();
    }
    
    public class EndTurnState : RoundState
    {
        public override void Update()
        {
            
        }

        public override RoundState GetNextRoundState() => new CardPickState();
    }
    
    public abstract class RoundState
    {
        public delegate void StateHandler();

        public StateHandler OnStart;
        public StateHandler OnEnd;

        protected virtual void Start()
        {
            OnStart?.Invoke();
        }

        protected virtual void End()
        {
            OnEnd?.Invoke();
        }
        public abstract void Update();
        public abstract RoundState GetNextRoundState();
    }

}