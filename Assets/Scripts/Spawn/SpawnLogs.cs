using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogs : MonoBehaviour
{
    public GameObject log;

    private int direction;
    private int delay = 5;
    private float timer;

    private void Start() {
        timer = Random.Range(0, 7);
        direction = -Mathf.RoundToInt(Mathf.Sign(gameObject.transform.position.x) * 1);
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer >= delay) {
            CreateLog();
            timer = 0;
        }
    }

    private void CreateLog() {
        GameObject obj = Instantiate(log, transform.position, Quaternion.identity);
        obj.transform.parent = transform;
        obj.GetComponent<Log>().SetDirection(direction);
    }
}
