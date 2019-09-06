using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {
    public int highScore;
    public int lotusCount;

    public Data (Score score)
    {
        highScore = score.GetHighScore();
        lotusCount = CollectLotus.Instance.GetCount();
    }
}
