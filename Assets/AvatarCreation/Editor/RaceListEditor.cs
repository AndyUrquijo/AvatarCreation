using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using UnityEditor;
using System.Collections.Generic;

public class RaceListEditor  
{
    public ReorderableList list;
    public List<AvatarListEditor> avatarListEditors = new List<AvatarListEditor>();

    private bool showList = true;

    public RaceListEditor(SerializedObject serializedObject)
    {
        SerializedProperty racesProperty = serializedObject.FindProperty("races");
        list = new ReorderableList(serializedObject, racesProperty,
        true, false, true, true);
        list.headerHeight = 0;
        list.elementHeightCallback = GetElementHeight;
        list.drawElementCallback = DrawElement;
        list.onAddCallback = AddElement;
        list.onChangedCallback =
                (ReorderableList relist) => {
                    UpdateListEditors();
                };

        UpdateListEditors();
    }

    private void UpdateListEditors()
    {
        avatarListEditors.Clear();
        for (int index = 0; index < list.serializedProperty.arraySize; index++)
        {
            SerializedProperty raceProperty = list.serializedProperty.GetArrayElementAtIndex(index);
            SerializedProperty avatarsProperty = raceProperty.FindPropertyRelative("avatars");
            SerializedProperty raceNameProperty = raceProperty.FindPropertyRelative("raceName");
            avatarListEditors.Add(new AvatarListEditor(raceProperty.serializedObject, avatarsProperty, raceNameProperty));
            avatarListEditors[index].UpdateHeight();
        }
    }

    private float GetElementHeight(int index)
    {
        return avatarListEditors[index].height;
    }

    private void AddElement(ReorderableList _list)
    {
        var index = _list.serializedProperty.arraySize;
        _list.serializedProperty.arraySize++;
        _list.index = index;
        SerializedProperty raceProperty = _list.serializedProperty.GetArrayElementAtIndex(index);
        raceProperty.FindPropertyRelative("raceName").stringValue = "(Race)";
    }

    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        avatarListEditors[index].DrawGUI(rect);
    }

    public void DrawGUI()
    {
        foreach (var avatarLis in avatarListEditors)
        {
            //EditorGUILayout.FloatField(avatarLis.height);
        }
        showList = EditorGUILayout.Foldout(showList, "Races");
        if (showList)
        {
            list.DoLayoutList();
        }
    }

    public void AddRace(string name)
    {
    }
}
