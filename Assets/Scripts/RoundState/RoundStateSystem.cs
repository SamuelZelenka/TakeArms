using UnityEngine;

namespace TakeArms.Systems
{
    public class RoundStateSystem : MonoBehaviour
    {

        private RoundState roundState;


        private void Start()
        {
            roundState = new CardPickState();
        }

        private void Update()
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

