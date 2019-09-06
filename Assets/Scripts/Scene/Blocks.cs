using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject startBlock;

    private List<GameObject> blockObjects;

    private float width;
    private float length;

    private void Start() {
        blockObjects = new List<GameObject>();
        width = startBlock.GetComponent<Renderer>().bounds.size.x;
        length = startBlock.GetComponent<Renderer>().bounds.size.y;

        CreateBlock(blocks[Random.Range(0, blocks.Length)],length);
        CreateBlock(startBlock, 0);
        CreateBlock(blocks[Random.Range(0, blocks.Length)],-length);
    }

    private void Update() {
        if (Globals.gameState == GameStates.notPlaying) {
            return;
        }
        foreach (GameObject obj in blockObjects)
        {
            float camPos = Camera.main.transform.position.y;
            float objPos = obj.transform.position.y;

            if (camPos - objPos > (length))
            {
                DestroyAndReplace(obj);
                break;
            }
        }
    }

    private void CreateBlock(GameObject block, float y) {
        Vector3 pos = new Vector2(0, y);
        GameObject obj = Instantiate(block, pos, Quaternion.Euler(0, 0, 0));
        blockObjects.Add(obj);
        SpawnFish.Instance.SpawnWithin(obj, obj.transform.position.x, obj.transform.position.y, width /2, length /2, Random.Range(1,5));
    }

    private void DestroyAndReplace(GameObject obj) {
        blockObjects.Remove(obj);
        CreateBlock(blocks[Random.Range(0, blocks.Length)], obj.transform.position.y + (length * 3));
        Destroy(obj);
    }
}
