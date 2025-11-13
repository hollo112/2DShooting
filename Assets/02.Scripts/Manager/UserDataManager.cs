using UnityEngine;

public class UserData
{
    public int Score = 0;
    public int Coin = 0;
    public string UserName = "Player";
}

public class UserDataManager
{
    private const string UserDataKey = "UserData";

    private static UserData _cachedData;

    public static UserData Data
    {
        get
        {
            if (_cachedData == null)
                Load();
            return _cachedData;
        }
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson(_cachedData);
        PlayerPrefs.SetString(UserDataKey, json);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        string json = PlayerPrefs.GetString(UserDataKey, string.Empty);
        if (string.IsNullOrEmpty(json))
        {
            _cachedData = new UserData(); 
        }
        else
        {
            _cachedData = JsonUtility.FromJson<UserData>(json);
        }
    }

    public static void ResetData()
    {
        PlayerPrefs.DeleteKey(UserDataKey);
        _cachedData = new UserData();
    }
}
