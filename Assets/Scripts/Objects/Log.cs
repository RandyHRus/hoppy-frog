using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private int direction;
    private float speed = 1;
    private float camWidth;

    private void Start() {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);
        Destroy();
    }

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    public int GetDirection() {
        return direction;
    }

    public float GetSpeed(){
        return speed;
    }

    private void Destroy()
    {
        if (direction == 1)
        {
            if (transform.position.x > ((camWidth / 2) + (GetComponent<Renderer>().bounds.size.x / 2)))
            {
                Destroy(gameObject);
            }
        } else {
            if (transform.position.x < -((camWidth / 2) + (GetComponent<Renderer>().bounds.size.x / 2)))
            {
                Destroy(gameObject);
            }
        }
    }

}
