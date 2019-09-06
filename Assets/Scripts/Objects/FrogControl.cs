using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogControl : MonoBehaviour
{
    private static readonly float maxCharge = 1.3f;
    private static readonly int jumpSpeed = 10;
    private static readonly float chargeDrainSpeed = 3.2f;

    private enum States { resting, charging, jumping };
    private States state;

    private Animator animator;
    private GameObject objectOn;
    private GameObject energyBar;
    private Vector2 dragStart, dragEnd;
    private float charge;
    private float energy;
    private float camWidth, camHeight;
    private bool InputHolding;
    private bool InputRelease;

    private void Start()
    {
        energyBar = GameObject.FindWithTag("EnergyBarCanvas");
        camHeight = 2f * Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        energyBar.SetActive(false);
        charge = 0;
        objectOn = null;
        state = States.resting;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Globals.gameState == GameStates.notPlaying)
        {
            return;
        }
        InputHolding = Input.GetMouseButtonDown(0);
        InputRelease = Input.GetMouseButtonUp(0);
        switch (state)
        {
            case States.resting:
                Idle();
                Resting();
                break;
            case States.charging:
                Idle();
                Charge();
                break;
            case States.jumping:
                Jump();
                break;
        }
        //CheckOutOfPlayArea();
    }

    private void Resting() {
        if (InputHolding) {
            StartCharge();
        }
    }

    private void StartCharge() {
        energyBar.SetActive(true);
        energyBar.transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

        dragStart = Input.mousePosition;
        state = States.charging;
        Charge();
    }

    private void Charge() {
        dragEnd = Input.mousePosition;
        Vector2 direction = dragStart - dragEnd;
        if (direction.x != 0 && direction.y != 0) {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        Vector2 offset = Camera.main.ScreenToWorldPoint(dragEnd) - Camera.main.ScreenToWorldPoint(dragStart);
        Vector2 clamped = Vector2.ClampMagnitude(offset, maxCharge);
        charge = Vector2.Distance(new Vector2(0, 0), clamped);

        if (charge > maxCharge) {
            charge = maxCharge;
        }
        energyBar.GetComponentInChildren<EnergyBar>().UpdateBar(charge, maxCharge);

        if (InputRelease) {
            StartJump();
            return;
        }
    }

    private void Idle() {
        if (objectOn != null) {
            transform.localScale = objectOn.transform.localScale;
            if (objectOn.tag == "Log") {
                MoveWithLog();
            }
        }
    }

    private void StartJump() {
        animator.SetTrigger("Jump");
        transform.localScale = new Vector2(1, 1);
        state = States.jumping;
        energy = charge;
        charge = 0;
        energyBar.SetActive(false);
        objectOn = null;
    }

    private void Jump()
    {
        if (energy > 0)
        {
            transform.position += (transform.up * jumpSpeed * Time.deltaTime);
            energy -= (chargeDrainSpeed * Time.deltaTime);
        }
        if (energy <= 0)
        { //make sure not to use else here because it may turn 0 in the step before
            Land();
            state = States.resting;
        }
    }
    private void Land() {
        animator.SetTrigger("Land");
        if (!CollisionJumpOn())
        {
            GameControl.Instance.GameOver();
        }
    }

    private bool CollisionJumpOn()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position, new Vector2(0.2f, 0.2f), 0, 1 << 8);

        if (col == null) {
            objectOn = null;
            return false;
        }
        else {
            objectOn = col.gameObject;

            objectOn.GetComponent<JumpBob>().StartWiggle();

            if (objectOn.tag == "Lily" && objectOn.GetComponent<Lily>().IsLotusOn()) {
                CollectLotus.Instance.GainLotus(objectOn.GetComponent<Lily>().GetLotus());
            }
            return true;
        }
    }

    private void MoveWithLog() {
        int direction = objectOn.GetComponent<Log>().GetDirection();
        float speed = objectOn.GetComponent<Log>().GetSpeed();
        transform.position = new Vector2(transform.position.x + (direction * speed * Time.deltaTime), transform.position.y);
    }

    private void CheckOutOfPlayArea() {
        if (Mathf.Abs(transform.position.x) > ((camWidth / 2) + (GetComponent<Renderer>().bounds.size.x / 2))) {
            GameControl.Instance.GameOver();
        }
        if (Mathf.Abs(transform.position.y) < (Camera.main.transform.position.y - ((camHeight / 2) + (GetComponent<Renderer>().bounds.size.y / 2)))) {
            GameControl.Instance.GameOver();
        }
    }

    public float GetEnergy() {
        return energy;
    }

}
