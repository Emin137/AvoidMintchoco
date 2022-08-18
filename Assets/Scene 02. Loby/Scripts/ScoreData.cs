using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData 
{
    public int score;
    public int coin;


    // 아이템 생성자
    public ScoreData(int coin, int score)
    {
        this.coin = coin;
        this.score = score;
    }
}
