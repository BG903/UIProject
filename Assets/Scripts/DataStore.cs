using System.Collections.Generic;

public class UserData{
    public string UserName { get;  }
    public string Password { get;  }
    public string Gender { get;  }
    public UserData(string userName,string password)
    {
        UserName = userName;
        Password = password;
    }
}
public static class DataStore{
     private static List<UserData> _userDatas = new List<UserData>
        {
            new UserData("admin", "1234"),
            new UserData("moderator", "qqqqqq")
        };

        public static bool TryFind(string username, string password, out UserData userData)
        {
            userData = _userDatas.Find(data => username == data.UserName && password == data.Password);
            return userData != null;
        }
        public static void AddUser(UserData userData){
            _userDatas.Add(userData);
        }
}