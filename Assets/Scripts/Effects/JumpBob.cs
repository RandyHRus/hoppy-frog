using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBob : MonoBehaviour
{
    public GameObject ripple;

    private float amplitude;
    private float period = 0.1f;
    private float shrinkSpeed = 0.05f;
    private float maxAmplitude = 0.1f;
    private float timer;
    private float size;
    private bool wiggling = false;

    public void StartWiggle() {
        size = 1;
        timer = 0;
        amplitude = maxAmplitude;
        wiggling = true;

        if (gameObject.tag == "Log")
        {
            GetComponent<Bob>().enabled = false;
        }
    }

    private void Update() {
        if (wiggling) {
            timer += Time.deltaTime;
            float theta = timer / period;
            float previousSize = size;
            size = -(Mathf.Sin(theta) * amplitude) + 1;
            transform.localScale = new Vector2(size, size);

            if (size < 1 && previousSize >= 1) {
                CreateRipple();
            }
            amplitude -= shrinkSpeed * Time.deltaTime;
            if (amplitude <= 0) {
                transform.localScale = new Vector2(1, 1);
                wiggling = false;
                if (gameObject.tag == "Log")
                {
                    GetComponent<Bob>().enabled = true;
                }
            }
        }
    }

    private void CreateRipple() {
        GameObject r = Instantiate(ripple, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        r.GetComponent<Ripple>().SetRadius(GetComponent<Renderer>().bounds.size.y / 2.8f);
        if (gameObject.tag == "Log")
        {
            r = Instantiate(ripple, new Vector2(transform.position.x + 0.7f, transform.position.y), Quaternion.identity);
            r.GetComponent<Ripple>().SetRadius(GetComponent<Renderer>().bounds.size.y / 2.8f);
            r = Instantiate(ripple, new Vector2(transform.position.x - 0.7f, transform.position.y), Quaternion.identity);
            r.GetComponent<Ripple>().SetRadius(GetComponent<Renderer>().bounds.size.y / 2.8f);
        }
    }
}
