using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPS : MonoBehaviour
{
    public TextMeshProUGUI text;
    float timer;

    private void Start()
    {
         timer = 0.2f;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            text.text = (1.0f / Time.deltaTime).ToString();
            timer = 0.2f;
        }
    }
}
