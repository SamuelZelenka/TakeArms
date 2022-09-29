namespace TakeArms.Systems
{
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