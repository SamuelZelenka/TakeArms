using TakeArms.Gameplay;
using UnityEngine;

namespace TakeArms.Systems
{
    public class CardSystem
    {
        public static CardSelection cardInspect;

        public CardSystem()
        {
            cardInspect = GameObject.FindObjectOfType<CardSelection>();
        }
    }
}
