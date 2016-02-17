using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class SelectionChanger : MonoBehaviour 
{
    public enum SelectionAttribute { GENDER, RACE, AGE };

    public SelectionAttribute attribute;

    Text SelectionText;

    void Start()
    {

        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
            if (text.name == "Selection")
                SelectionText = text;

    }

    void Update()
    {
        UpdateSelectionName();
    }

    void UpdateSelectionName()
    {
        switch (attribute)
        {
            case SelectionAttribute.GENDER:
                SelectionText.text = "\n" + UserData.Gender.ToString();
                break;
            case SelectionAttribute.RACE:
                SelectionText.text = "\n" + UserData.Race.ToString();
                break;
            case SelectionAttribute.AGE:
                SelectionText.text = "\n" + UserData.Age.ToString();
                break;
        }
    }

    public void Left()
    {
        switch (attribute)
        {
            case SelectionAttribute.GENDER:
                UserData.Gender = EnumUtil.GetPrev(UserData.Gender);
                break;
            case SelectionAttribute.RACE:
                UserData.Race = EnumUtil.GetPrev(UserData.Race);
                break;
            case SelectionAttribute.AGE:
                UserData.Age = EnumUtil.GetPrev(UserData.Age);
                break;
        }
        UpdateSelectionName();
    }
    public void Right()
    {
        switch (attribute)
        {
            case SelectionAttribute.GENDER:
                UserData.Gender = EnumUtil.GetNext(UserData.Gender);
                break;
            case SelectionAttribute.RACE:
                UserData.Race = EnumUtil.GetNext(UserData.Race);
                break;
            case SelectionAttribute.AGE:
                UserData.Age = EnumUtil.GetNext(UserData.Age);
                break;
        }
        UpdateSelectionName();
    }

}
