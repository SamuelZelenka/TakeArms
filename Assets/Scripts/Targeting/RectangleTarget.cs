using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.TargetVisualizers
{
    public class RectangleTarget
    {
        private enum RectangleEdge
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private List<Vector2Int> rectangleCoordinates = new List<Vector2Int>();

        Vector2Int[] GetCoordinates(Vector2Int p1, Vector2Int p2)
        {
            if (expr)
            {
            }

            return rectangleCoordinates.ToArray();
        }

        Vector2Int[] GetCorners(Vector2Int p1, Vector2Int p2) => new Vector2Int[] {p1, p2, new Vector2Int(p2.x, p1.y), new Vector2Int(p1.x, p2.y)};

        Vector2Int[] GetSortedCorners(Vector2Int[] corners)
        {
            Vector2Int[] sortedCorners = new Vector2Int[4];
            
            bool isP1XLessThanP2X = corners[0].x <= corners[1].x;
            bool isP1YGreaterThanP2Y = corners[0].y >= corners[1].y;
            bool isP1TopLeft = isP1XLessThanP2X && isP1YGreaterThanP2Y;

            int p1IsTopLeft = isP1TopLeft ? 1 : 0;
            int p2IsTopLeft = p1IsTopLeft == 0 ? 1 : 0;

            sortedCorners[0] = corners[0 + p2IsTopLeft];
            sortedCorners[1] = corners[2 + p2IsTopLeft];
            sortedCorners[2] = corners[0 + p1IsTopLeft];
            sortedCorners[3] = corners[2 + p1IsTopLeft];

            return sortedCorners;
        }
        void GetTopEdge()
        {
        }

        void GetBottomEdge()
        {
        }

        void GetLeftEdge()
        {
        }

        void GetRightEdge()
        {
        }
    }
}