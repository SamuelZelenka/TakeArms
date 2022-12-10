using System.Collections.Generic;
using UnityEngine;
using TakeArms.Utility;

public class CardHandUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cards;

    public Vector3 curveStartPos;
    public Vector3 curveEndPos;
    public Vector3 curveStartHandle;
    public Vector3 curveEndHandle;

    public Vector3 cardLookAtPoint;

    public CardSelection cardInspect;

    [SerializeField]
    private int _maxHandSize = 10;

    [SerializeField]
    private float _spacing = 1;

    [Range(0,1)]
    [SerializeField]
    private float posT;

    private int _handIndex;
    private int _handCount;

    private void Update()
    {
        if (cards.Count > _maxHandSize)
        {
            Debug.LogError("Too many cards in hand");
            return;
        }
        if (cards.Count > 0)
        {
            float t = 1f / _maxHandSize;

            for (int i = 0; i < cards.Count; i++)
            {
                var orderPosition = (_maxHandSize / 2 - i);
                cards[i].transform.position = GetCardHandPos(curveStartPos, t * orderPosition);
                cards[i].transform.rotation = GetCardHandRotation(cards[i].transform.position);
            }
        }
    }

    public Vector3 GetCardHandPos(Vector3 previousPos, float t)
    {
        var offset = new Vector3(cards.Count * _spacing, 0, 0);
        var scaledStartPos = curveStartPos - offset;
        var scaledEndPos = curveEndPos + offset;

        return Trajectories.GetBezierPos(scaledStartPos, scaledEndPos, curveStartHandle, curveEndHandle, t);
    }

    public Quaternion GetCardHandRotation(Vector3 cardPos)
    {
        var direction = cardLookAtPoint - cardPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0,0,90);
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 previous = curveStartPos;

        for (float i = 0; i < 1; i += 0.01f)
        {
            Vector3 next = Trajectories.GetBezierPos(curveStartPos, curveEndPos, curveStartHandle, curveEndHandle, i);
            Gizmos.DrawLine(previous, next);
            previous = next;
        }
    }
#endif
}
