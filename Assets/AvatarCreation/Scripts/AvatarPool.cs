using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AvatarPool : MonoBehaviour 
{

    [Serializable]
    public class Race
    {
        public string raceName;
        public List<Avatar> avatars = new List<Avatar>();

    }

    [HideInInspector]
    public List<Race> races = new List<Race>();


    [Serializable]
    public class Avatar
    {
        public GameObject Prefab;
    }

    public RuntimeAnimatorController controller;

    GameObject currentModel;

    Race currentRace;
    int raceIndex = 0;
    int avatarindex = 0;

    public UnityEngine.UI.Text raceText;


    void Start()
    {
        if (currentRace == null && races.Count > 0)
        {
            currentRace = races[0];
            raceText.text = currentRace.raceName;
        }

        if (currentRace != null && currentModel == null && currentRace.avatars.Count > 0)
            UpdateModel();
    }

    public void NextRace()
    {
        Debug.Log("raceIndex " + raceIndex);
        if (races.Count == 0)
            return;

        raceIndex++;
        raceIndex %= races.Count;
        currentRace = races[raceIndex];

        avatarindex = 0;
        UpdateModel();
        raceText.text = currentRace.raceName;
    }

    public void NextAvatar()
    {
        Debug.Log("avatarindex " + avatarindex);
        if (currentRace == null || currentRace.avatars.Count == 0)
            return;
        avatarindex++;
        avatarindex %= currentRace.avatars.Count;

        UpdateModel();
    }

    public void UpdateModel()
    {
        if (currentRace == null)
            return;

        GameObject currentSelection;

        if (avatarindex >= currentRace.avatars.Count)
            currentSelection = null;
        else
            currentSelection = currentRace.avatars[avatarindex].Prefab;


        if (currentModel && currentSelection && currentSelection.name == currentModel.name)
            return;

        if(Application.isEditor)
            GameObject.DestroyImmediate(currentModel);
        else
            GameObject.Destroy(currentModel);

        if(currentSelection)
        {
            currentModel = GameObject.Instantiate(currentSelection);
            currentModel.transform.position = transform.position;
            currentModel.transform.parent = transform;
            Animator animator = currentModel.GetComponent<Animator>();
            animator.runtimeAnimatorController = controller;
        }
    }
}
