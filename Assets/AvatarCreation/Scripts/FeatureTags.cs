using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class FeatureTags : MonoBehaviour
{
    public enum GENDER { Male, Female };
    public enum RACE { Asian, Black, Hispanic, White };
    public enum AGE { _15, _16, _17  };

    public GENDER Gender;
    public RACE Race;
    public AGE Age;

    public bool FilterSelection;

    GameObject child;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    void Update () 
	{
        if (!FilterSelection)
            return;

        bool active = true;

        if (Gender != UserData.Gender)
            active = false;
        if (Race != UserData.Race)
            active = false;
        if (Age != UserData.Age)
          active = false;

        child.SetActive(active);
	}
}
