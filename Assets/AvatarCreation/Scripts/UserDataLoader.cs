using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(UserDataLoader))]
public class UserDataLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
            UserData.SaveOptions();
        if (GUILayout.Button("Load"))
            UserData.LoadOptions();
        GUILayout.EndHorizontal();

    }
}
#endif

public class UserDataLoader : MonoBehaviour 
{
	void OnEnable()
    {
        UserData.LoadOptions();
    }

    void OnDisable()
    {
        UserData.SaveOptions();
    }
}
