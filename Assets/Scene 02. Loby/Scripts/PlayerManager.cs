using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static List<PlayerData> playerDataList = new List<PlayerData>();

    public static void AddPlayer(PlayerData playerData)
    {
        playerDataList.Add(playerData);
    }

    public static List<PlayerData> GetPlayerList()
    {
        return playerDataList;
    }

    private void Awake()
    {
        AddPlayer(new PlayerData("01", "White"));
        AddPlayer(new PlayerData("02", "Mint"));
        AddPlayer(new PlayerData("03", "Red"));
    }
}
