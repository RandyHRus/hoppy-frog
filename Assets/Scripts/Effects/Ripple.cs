using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ripple : MonoBehaviour
{
    float theta_scale = 0.01f;        //Set lower to add more points
    int size; //Total number of points in circle
    float radius;
    float speed = 0.3f;
    float alpha = 255;
    LineRenderer lineRenderer;

    void Start()
    {
        float sizeValue = (2.0f * Mathf.PI) / theta_scale;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.sortingLayerName = "Ripple";
        Color col = new Color32(197, 255, 253, 255);
        lineRenderer.startColor = col;
        lineRenderer.endColor = col;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = size;
    }

    void Update()
    {
        radius += speed * Time.deltaTime;
        Vector2 pos;
        float theta = 0f;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * theta_scale);
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            pos = new Vector2(x, y);
            lineRenderer.SetPosition(i, pos);
        }

        alpha -= 100 * Time.deltaTime;
        byte a = (byte)alpha;
        Color col = new Color32(197, 255, 253, a);
        if (alpha <= 0) {
            Destroy(gameObject);
            return;
        }
        lineRenderer.startColor = col;
        lineRenderer.endColor = col;
    }

    public void SetRadius(float r) {
        radius = r;
    }
}