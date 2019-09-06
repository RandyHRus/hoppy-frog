using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject frog;
    private int score;
    private int highScore;

    void Start() {
        score = 0;
        UI.Instance.ChangeHighScore(highScore);
    }

    void Update() {
        if (Globals.gameState == GameStates.notPlaying) {
            return;
        }
        int pos = Mathf.RoundToInt(frog.transform.position.y / 3);
        if (pos > score) {
            score = pos;
        }

        UI.Instance.ChangeScore(score);
    }

    public int GetHighScore() {
        return highScore;
    }

    public void SetHighScore(int num) {
        highScore = num;
    }

    public void UpdateHighScore() {
        if (score > highScore) {
            highScore = score;
            UI.Instance.ChangeHighScore(highScore);
        } 
    }
}
