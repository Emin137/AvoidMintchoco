using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static List<ScoreData> scoreDataList = new List<ScoreData>();

    public static List<ScoreData> GetScoreData()
    {
        return scoreDataList;
    }

    public static void AddScore(ScoreData scoreData)
    {
        scoreDataList.Add(scoreData);
    }
}
