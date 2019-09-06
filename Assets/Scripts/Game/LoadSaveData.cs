using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadSaveData
{
    public static void Load()
    {
        Score score = GameObject.Find("Controller").GetComponent<Score>();
        Data data = SaveData.Load();
        if (data == null)
        {
            score.SetHighScore(0);
            CollectLotus.Instance.SetCount(0);
        }
        else
        {
            score.SetHighScore(data.highScore);
            CollectLotus.Instance.SetCount(data.lotusCount);
        }
    }
}
