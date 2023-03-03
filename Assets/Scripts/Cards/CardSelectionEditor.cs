using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

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
#endif