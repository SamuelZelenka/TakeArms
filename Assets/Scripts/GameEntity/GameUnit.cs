using System;
using System.Collections;
using System.Collections.Generic;
using Configurations;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public Vector2Int boardPosition;
    public UnitConfiguration unitConfig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(GameBoard.GetWorldPosFromBoardPos(boardPosition), 0.2f);
    }
}
