using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material;
    float offset;

    public float velocity;
    public float startingOffset;

    void Awake() {
        material = GetComponent<Renderer>().material;
    }

    void Start() {
        offset = velocity;
        material.mainTextureOffset += new Vector2(0,startingOffset);
    }

    void Update() {
        if (Globals.gameState == GameStates.notPlaying) {
            return;
        }
        material.mainTextureOffset += new Vector2(0, offset) * Time.deltaTime;
    }
}
