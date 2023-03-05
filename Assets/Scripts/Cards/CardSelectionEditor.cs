using UnityEngine;
using TakeArms.Gameplay;
using UnityEditor;

#if UNITY_EDITOR
namespace TakeArms.Editors
{
    [CustomEditor(typeof(CardSelection))]
    public class CardSelectionEditor : Editor
    {
        private void OnSceneGUI()
        {
            CardSelection cardSelection = (CardSelection)target;

            EditorGUI.BeginChangeCheck();

            var newCurveStartHandle = Handles.PositionHandle(cardSelection.startHandle, Quaternion.identity);
            var newCurveEndHandle = Handles.PositionHandle(cardSelection.endHandle, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                cardSelection.startHandle = newCurveStartHandle;
                cardSelection.endHandle = newCurveEndHandle;
            }
        }
    }
}
#endif
