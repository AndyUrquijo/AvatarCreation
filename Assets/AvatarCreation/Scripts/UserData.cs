using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


/// <summary>
/// Stores user data and serves as an interface to fetch that data from the server database. Data.
/// </summary>
[Serializable]
public class UserData 
{
    public static UserData Instance = null;

    [SerializeField] int gender;
    static public FeatureTags.GENDER Gender
    {
        get { return EnumUtil.ToEnum<FeatureTags.GENDER>(Instance.gender);  }
        set { Instance.gender = EnumUtil.ToInt(value); }
    }

    [SerializeField] int race;
    static public FeatureTags.RACE Race
    {
        get { return EnumUtil.ToEnum<FeatureTags.RACE>(Instance.race);  }
        set { Instance.race = EnumUtil.ToInt(value); }
    }

    [SerializeField] int age;
    static public FeatureTags.AGE Age
    {
        get { return EnumUtil.ToEnum<FeatureTags.AGE>(Instance.age);  }
        set { Instance.age = EnumUtil.ToInt(value); }
    }

    static string FILE_LOCATION = Application.dataPath + "/AvatarCreation/Data/UserData.dat";

    public static void SaveOptions()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(FILE_LOCATION);
        formatter.Serialize(file, Instance);
        file.Close();

    }

    public static void LoadOptions()
    {
        if (!File.Exists(FILE_LOCATION))
            return;

        Instance = new UserData();
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(FILE_LOCATION, FileMode.Open, FileAccess.Read);
        Instance = (UserData)formatter.Deserialize(file);
        file.Close();
    }

}
