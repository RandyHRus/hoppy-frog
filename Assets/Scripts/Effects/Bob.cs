using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    Vector3 startPos;
    private float amplitude = 0.1f;
    private  float period = 1;
    private float timer = 0;

    private void OnEnable() {
        timer = 0;
    }

    private void Update() {
        timer += Time.deltaTime;
        float theta = timer / period;
        float size = (Mathf.Sin(theta) * amplitude) + 1;
        transform.localScale = new Vector2(size, size);
    }
}
