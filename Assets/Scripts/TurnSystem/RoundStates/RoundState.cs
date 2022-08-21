using TakeArms.Services;

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
    
    public class PlayTurnState : RoundState
    {
        public override void Start()
        {
            base.Start();
            GameSystemService.TurnSystem.ShowCurrentPlayer(true);
        }
        public override void Update()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.RightControl))
            {
                GameSystemService.TurnSystem.NextPlayerTurn();
            }
        }

        public override void End()
        {
            base.End();
            GameSystemService.TurnSystem.ShowCurrentPlayer(false);
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

        public virtual void Start()
        {
            OnStart?.Invoke();
        }

        public virtual void End()
        {
            OnEnd?.Invoke();
        }
        public abstract void Update();
        public abstract RoundState GetNextRoundState();
    }

}