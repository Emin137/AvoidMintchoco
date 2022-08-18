using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    private static List<UserData> userDatas = new List<UserData>();

    public static void AddUserData(UserData userData)
    {
        userDatas.Add(userData);
    }

    public static UserData GetUserData(string name)
    {
        for (int i = 0; i < userDatas.Count; i++)
        {
            if (userDatas[i].UserName == name)
                return userDatas[i];
        }
        return null;
    }

    
}
