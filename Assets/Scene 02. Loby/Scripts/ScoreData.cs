using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData 
{
    public int score;
    public int coin;


    // ������ ������
    public ScoreData(int coin, int score)
    {
        this.coin = coin;
        this.score = score;
    }
}
