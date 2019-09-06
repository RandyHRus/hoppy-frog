using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private enum States { idle, swimming, rotating };
    private States state;

    private float rotateSpeed = 0.3f;

    Animator anim;
    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;

    private float timer;
    private float swimTimer;
    private float swimTime;

    private float driftSpeed = 0.15f;


    private void Start() {
        StartIdle();
        anim = transform.GetChild(0).GetComponent<Animator>();
        anim.Play("swim", -1, Random.Range(0.0f, 1.0f));
        anim.speed = 2f;
    }

    void Update() {
        transform.position = new Vector2(transform.position.x + (driftSpeed * Time.deltaTime), transform.position.y + (driftSpeed * Time.deltaTime));
        switch (state) {
            case States.idle:
                Idle();
                break;
            case States.swimming:
                Swim();
                break;
            case States.rotating:
                Rotate();
                break;
        }
    }

    void StartIdle() {
        state = States.idle;
        timer = Random.Range(0.5f, 1f);
    }

    void StartRotating() {
        float zPosition = Random.Range(transform.position.z - 120f, transform.position.z + 120f);
        state = States.rotating;
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zPosition);
        rotationProgress = 0;
    }

    private void StartSwimming() {
        state = States.swimming;
        swimTime = Random.Range(0.5f, 2f);
        swimTimer = 0;
    }

    private void Idle()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            if (Random.Range(0f,1f) < 0.5f) {
                StartRotating();
            }
        }
    }

    private void Rotate(){
        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * rotateSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }
        else {
            StartSwimming();
        }
    }

    private void Swim() {
        swimTimer += Time.deltaTime;
        float theta = swimTimer / swimTime;
        float speed = Mathf.Sin(theta);
        if (speed <= 0) {
            StartIdle();
        }
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
