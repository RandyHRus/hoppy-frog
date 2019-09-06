using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 mouseA;
    private Vector3 mouseB;

    public Transform circle;
    public Transform outerCircle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseA = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            pointA = Camera.main.ScreenToWorldPoint(mouseA);

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            mouseB = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            pointB = Camera.main.ScreenToWorldPoint(mouseB);
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - Camera.main.ScreenToWorldPoint(mouseA);
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.3f);

            circle.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(mouseA).x + direction.x, Camera.main.ScreenToWorldPoint(mouseA).y + direction.y);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}