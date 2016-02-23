using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

public class AvatarPool : MonoBehaviour 
{

    [Serializable]
    public class Race
    {
        public string raceName;
        public List<Avatar> avatars = new List<Avatar>();

    }

    [HideInInspector]  public List<Race> TeacherFemales = new List<Race>();
    [HideInInspector]  public List<Race> TeacherMales = new List<Race>();
    [HideInInspector]  public List<Race> StudentFemales = new List<Race>();
    [HideInInspector]  public List<Race> StudentMales = new List<Race>();


    [Serializable]
    public class Avatar
    {
        public GameObject Prefab;
        public string path;
    }

    public RuntimeAnimatorController controller;

    List<Race> currentRaceList;
    GameObject currentModel;

    Race currentRace;
    int raceIndex = 0;
    int avatarindex = 0;

    public enum GENDER { Male, Female };
    GENDER currentGender = GENDER.Male;

    public enum ROLE { Teacher, Student };
    ROLE currentRole = ROLE.Teacher;

    public UnityEngine.UI.Text genderText;
    public UnityEngine.UI.Text roleText;
    public UnityEngine.UI.Text raceText;


    void Start()
    {
        UpdateRaceList();

        LoadAvatar();


        if (currentRace == null && currentRaceList.Count > 0)
        {
            currentRace = currentRaceList[0];
            raceText.text = currentRace.raceName;
        }

        if (currentRace != null && currentModel == null && currentRace.avatars.Count > 0)
            UpdateModel();
    }

    public void ToggleGender()
    {
        if (currentGender == GENDER.Male)
            currentGender = GENDER.Female;
        else
            currentGender = GENDER.Male;

        UpdateRaceList();
    }

    public void ToggleRole()
    {
        if (currentRole == ROLE.Teacher)
            currentRole = ROLE.Student;
        else
            currentRole = ROLE.Teacher;

        UpdateRaceList();
    }

    void UpdateRaceList()
    {
        if(currentRole == ROLE.Teacher)
        {
            if (currentGender == GENDER.Male)
                currentRaceList = TeacherMales;
            else
                currentRaceList = TeacherFemales;
        }
        else
        {
            if (currentGender == GENDER.Male)
                currentRaceList = StudentMales;
            else
                currentRaceList = StudentFemales;
        }

        genderText.text = currentGender.ToString();
        roleText.text = currentRole.ToString();

        if (currentRaceList.Count > 0)
            currentRace = currentRaceList[0];
        else
            currentRace = null;

        raceIndex = 0;
        avatarindex = 0;
        UpdateModel();
    }

    public void NextRace()
    {
        if (currentRaceList.Count == 0)
            return;

        raceIndex++;
        raceIndex %= currentRaceList.Count;
        currentRace = currentRaceList[raceIndex];

        avatarindex = 0;
        UpdateModel();
    }

    public void NextAvatar()
    {
        if (currentRace == null || currentRace.avatars.Count == 0)
            return;
        avatarindex++;
        avatarindex %= currentRace.avatars.Count;

        UpdateModel();
    }

    public void UpdateModel()
    {
        raceText.text = currentRace.raceName;

        GameObject currentSelection = null;

        if (currentRace != null)
        {
            if (avatarindex < currentRace.avatars.Count)
                currentSelection = currentRace.avatars[avatarindex].Prefab;
        }
      

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

    public void SaveAvatar()
    {
        PlayerPrefs.SetInt("currentRole", (int)currentRole);
        PlayerPrefs.SetInt("currentGender", (int)currentGender);
        PlayerPrefs.SetInt("raceIndex", raceIndex);
        PlayerPrefs.SetInt("avatarindex", avatarindex);

        PlayerPrefs.SetString("AvatarPath", currentRace.avatars[avatarindex].path);

        PlayerPrefs.Save();
    }

    public void LoadAvatar()
    {
        if (!PlayerPrefs.HasKey("currentRole"))
            return;

        int roleInt = PlayerPrefs.GetInt("currentRole");
        currentRole = (ROLE)roleInt;
        int genderInt = PlayerPrefs.GetInt("currentGender");
        currentGender = (GENDER)genderInt;

        UpdateRaceList();
        raceIndex = PlayerPrefs.GetInt("raceIndex");
        currentRace = currentRaceList[raceIndex];

        avatarindex = PlayerPrefs.GetInt("avatarindex");

        UpdateModel();

    }
}
