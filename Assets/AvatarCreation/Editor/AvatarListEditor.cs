using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using UnityEditor;

public class AvatarListEditor
{
    public ReorderableList list;
    public float height;
    SerializedProperty name;

    private bool showList = true;

    public AvatarListEditor(SerializedObject serializedObject, SerializedProperty serializedList, SerializedProperty serializedName)
    {
        name = serializedName;

        list = new ReorderableList(serializedObject,
        serializedList,
        true, false, true, true);
        list.headerHeight = 0;
        list.elementHeight = EditorGUIUtility.singleLineHeight + 5;
        list.drawElementCallback = DrawElement;
        list.showDefaultBackground = false;
    }

    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        var element = list.serializedProperty.GetArrayElementAtIndex(index);
        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative("Prefab"), GUIContent.none);
    }
    public void UpdateHeight()
    {
        int numLines = 1;
        if(showList)
        {
            int size = list.serializedProperty.arraySize;
            numLines += size == 0 ? 2 : size + 1;
        }
        height = list.elementHeight * numLines ;
    }

    public void DrawGUI(Rect rect)
    {
        Rect foldoutRect = new Rect(rect.x + 10, rect.y, rect.width - 10, EditorGUIUtility.singleLineHeight);
        name.stringValue = EditorGUI.TextField(foldoutRect, name.stringValue);
        foldoutRect.width = 0;
        showList = EditorGUI.Foldout(foldoutRect, showList, "");

        height = EditorGUIUtility.singleLineHeight*2;
        if (showList)
        {
            rect.height = height;
            //EditorGUI.DrawRect(rect, Color.green);
            rect.y += EditorGUIUtility.singleLineHeight;
            list.DoList(rect);
        }
        UpdateHeight();
    }
}
