using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandUI : MonoBehaviour
{

    [SerializeField]
    private GameObject[] cards;

    [SerializeField]
    private Transform _curveStartPos;

    [SerializeField]
    private Transform _curveEndPos;

    [SerializeField]
    private float curveHeight;

    [SerializeField]
    private float cardpos = 0.5f;
    private int _handIndex;
    private int _handCount;


    private void Update()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = GetCardHandPos(cardpos);
        }
    }


    private float GetDerivative(float x)
    {
        return Mathf.PI * curveHeight * Mathf.Cos(Mathf.PI * x);
    }

    public Vector3 GetCardHandPos(float t)
    {
        float xPos = t;
        float yPos = Mathf.Sin(xPos * Mathf.PI) * curveHeight;
        float magnitude = Vector3.Magnitude(_curveStartPos.transform.position - _curveEndPos.transform.position);
        Vector3 newPos = new Vector3(xPos, yPos, 0);
        newPos = newPos * magnitude + _curveStartPos.transform.position;

        return newPos;
    }
    public Quaternion GetCardHandRotation(float x, float y)
    {
        Vector3 newPos = new Vector3(GetDerivative(x), GetDerivative(y));
        
        return Quaternion.LookRotation(newPos);
    }

    private void OnDrawGizmos()
    {
        Vector3 previous = _curveStartPos.position;
       
        for (float i = 0; i < 1; i += 0.1f)
        {
            Vector3 next = GetCardHandPos(i);
            Gizmos.DrawLine(previous, next);
            Gizmos.color = Color.green;
            Vector3 normal = new Vector3(GetDerivative(next.x), GetDerivative(next.y), 0);
            normal.Set(normal.y, normal.x, 0);

            Gizmos.DrawLine(next, next + normal);
            Gizmos.color = Color.white;

            previous = next;

        }
        Gizmos.DrawLine(previous, _curveEndPos.transform.position);
    }
}
