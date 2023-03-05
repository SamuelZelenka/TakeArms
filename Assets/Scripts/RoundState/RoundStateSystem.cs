using UnityEngine;

namespace TakeArms.Systems
{
    public class RoundStateSystem
    {

        private RoundState roundState;

        public RoundStateSystem()
        {
            roundState = new CardPickState();
        }

        private void Update() // TODO: Figure out how to do this in player controller
        {
            roundState.Update();
        }

        public void NextRoundState()
        {
            roundState.End();
            roundState = roundState.GetNextRoundState();
            roundState.Start();
        }
        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 500, 100), "State: " + roundState.GetType());
        }
    }
}
