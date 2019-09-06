using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class plusOne : MonoBehaviour
{
    private float timer = 1;
    private float speed = 0.5f;
    private Color color;

    private void Start()
    {
        color = GetComponent<TextMeshProUGUI>().color;
    }
    void Update() {
        transform.Translate(0, speed * Time.deltaTime, 0);
        timer -= Time.deltaTime;
        color.a = timer;
        GetComponent<TextMeshProUGUI>().color = color;
        if (timer <= 0) {
            Destroy(gameObject);
        }
    }
}
