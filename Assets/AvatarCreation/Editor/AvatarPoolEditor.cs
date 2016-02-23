using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

[CustomEditor(typeof(AvatarPool))]
public class AvatarPoolEditor : Editor
{
    RaceListEditor TeacherFemalesEditor;
    RaceListEditor TeacherMalesEditor;
    RaceListEditor StudentFemalesEditor;
    RaceListEditor StudentMalesEditor;

    private void OnEnable()
    {
        TeacherFemalesEditor    = new RaceListEditor(serializedObject, "TeacherFemales");
        TeacherMalesEditor      = new RaceListEditor(serializedObject, "TeacherMales");
        StudentFemalesEditor    = new RaceListEditor(serializedObject, "StudentFemales");
        StudentMalesEditor      = new RaceListEditor(serializedObject, "StudentMales");
    }

    Rect createRaceRect;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        TeacherFemalesEditor.DrawGUI();
        TeacherMalesEditor.DrawGUI();
        StudentFemalesEditor.DrawGUI();
        StudentMalesEditor.DrawGUI();

        serializedObject.ApplyModifiedProperties();
    }

}
