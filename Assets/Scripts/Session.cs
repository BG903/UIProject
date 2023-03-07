using UnityEngine;
public static class Session{
private const string USERNAME_KEY="username";
private const string PASSWORD = "password";

    public static UserData UserData{get;private set;}

    public static void SetUserData(UserData userData){
        UserData = userData;
    }

    public static void SaveProfile(){
        if(UserData == null){
            return;
        }
        PlayerPrefs.SetString(USERNAME_KEY,UserData.UserName);
        PlayerPrefs.SetString(PASSWORD,UserData.Password);
        PlayerPrefs.Save();
    }
    public static void ClearProfile(){
        PlayerPrefs.DeleteKey(USERNAME_KEY);
        PlayerPrefs.DeleteKey(PASSWORD);
        PlayerPrefs.Save();
    }
    public static bool HasProfile(){
        return PlayerPrefs.HasKey(USERNAME_KEY);
    }
    public static UserData GetProfile(){
        string username = PlayerPrefs.GetString(USERNAME_KEY);
        string password = PlayerPrefs.GetString(PASSWORD);
        return new UserData(username,password);
    }
}