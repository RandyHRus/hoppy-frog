using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI scoreCounter;
    public TextMeshProUGUI highScoreCounter;
    public TextMeshProUGUI lotusCounter;
    public TextMeshProUGUI plusOne;

    private static UI _instance;
    public static UI Instance { get { return _instance; } }


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
    }

    public void ChangeScore(int score) {
        scoreCounter.text = score.ToString() + "m";
    }

    public void ChangeHighScore(int score)
    {
        highScoreCounter.text = "Highscore: " + score + "m";
    }

    public void GainLotus() {
        GameObject frog = GameObject.FindWithTag("Frog");
        Vector2 pos = (new Vector2(frog.transform.position.x + 0.2f, frog.transform.position.y + 0.2f));
        pos = WorldToUISpace(canvas, pos);
        TextMeshProUGUI t = Instantiate(plusOne);
        t.transform.SetParent(canvas.transform, false);
        t.transform.position = pos;
    }

    public void ChangeLotusCount(int count)
    {
        lotusCounter.text = count.ToString();
    }

    public Vector3 WorldToUISpace(Canvas parentCanvas, Vector2 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
