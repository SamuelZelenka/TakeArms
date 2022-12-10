using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem
{
    public static CardSelection cardInspect;

    public CardSystem()
    {
        cardInspect = GameObject.FindObjectOfType<CardSelection>();
    }
}
