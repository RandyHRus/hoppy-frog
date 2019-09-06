using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject storeButton;
    private Score score;

    private static GameControl _instance;
    public static GameControl Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        Application.targetFrameRate = 60;
    }

    private void Start() {
        Globals.gameState = GameStates.playing;
        LoadSaveData.Load();
        score = GetComponent<Score>();
        restartButton.SetActive(false);
        storeButton.SetActive(false);
    }

    public void GameOver() {
        Globals.gameState = GameStates.notPlaying;
        GameObject.FindWithTag("Controller").GetComponent<Joystick>().enabled = false;
        score.UpdateHighScore();
        restartButton.SetActive(true);
        storeButton.SetActive(true);
        SaveData.Save(score);
    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }
}

