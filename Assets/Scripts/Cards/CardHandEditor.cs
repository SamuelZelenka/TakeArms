using UnityEngine;
using UnityEditor;
using TakeArms.UI;

#if UNITY_EDITOR
namespace TakeArms.Editors
{
    [CustomEditor(typeof(CardHandUI))]
    public class CardHandEditor : Editor
    {
        private void OnSceneGUI()
        {
            CardHandUI cardHandUI = (CardHandUI)target;

            EditorGUI.BeginChangeCheck();

            var newCurveStartPos = Handles.PositionHandle(cardHandUI.curveStartPos, Quaternion.identity);
            var newCurveStartHandle = Handles.PositionHandle(cardHandUI.curveStartHandle, Quaternion.identity);
            var newCurveEndHandle = Handles.PositionHandle(cardHandUI.curveEndHandle, Quaternion.identity);
            var newCurveEndPos = Handles.PositionHandle(cardHandUI.curveEndPos, Quaternion.identity);

            var lookAtPoint = Handles.PositionHandle(cardHandUI.cardLookAtPoint, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(cardHandUI, "Change Look At Target Position");
                cardHandUI.curveStartPos = newCurveStartPos;
                cardHandUI.curveStartHandle = newCurveStartHandle;
                cardHandUI.curveEndHandle = newCurveEndHandle;
                cardHandUI.curveEndPos = newCurveEndPos;
                cardHandUI.cardLookAtPoint = lookAtPoint;
            }
        }
    }
}
#endif
