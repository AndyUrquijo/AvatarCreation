using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

[CustomEditor(typeof(AvatarPool))]
public class AvatarPoolEditor : Editor
{
    RaceListEditor raceListEditor;

    private void OnEnable()
    {
        raceListEditor = new RaceListEditor(serializedObject);
    }

    Rect createRaceRect;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        serializedObject.Update();
        raceListEditor.DrawGUI();

        serializedObject.ApplyModifiedProperties();
        if (false || GUILayout.Button("Clear"))
        {
            raceListEditor.avatarListEditors.Clear();
            AvatarPool pool = (AvatarPool)target;
            pool.races.Clear();
        }
        if (Event.current.type == EventType.Repaint) createRaceRect = GUILayoutUtility.GetLastRect();
    }

}
