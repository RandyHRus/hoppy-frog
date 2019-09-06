using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject Fish;

    private static SpawnFish _instance;
    public static SpawnFish Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SpawnWithin(GameObject parent, float middleX, float middleY, float width, float length, int count) {
        while (count > 0) {
            float x = middleX + Random.Range(-width, width);
            float y = middleY + Random.Range(-length, length);
            GameObject obj = Instantiate(Fish, new Vector2(x, y), Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f)));
            obj.transform.parent = parent.transform;
            count -= 1;
        }
    }
}
