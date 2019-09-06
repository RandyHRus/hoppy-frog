using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : MonoBehaviour
{
    public GameObject lotusPrefab;
    private GameObject lotusObject;
    private bool lotus = false;

    void Start() {
        transform.Rotate(0, 0,Random.Range(0f,360f));
        if (Random.Range(1,5) == 1) {
            lotus = true;
            lotusObject = Instantiate(lotusPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            lotusObject.transform.Rotate(0, 0, Random.Range(0f, 360f));
            lotusObject.transform.localScale = gameObject.transform.localScale;
            lotusObject.transform.parent = transform;
        }
    }

    public bool IsLotusOn() {
        return lotus;
    }
    public void SetLotus(bool b) {
        lotus = b;
    }

    public GameObject GetLotus() {
        return lotusObject;
    }
}
