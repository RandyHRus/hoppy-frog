using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private static readonly float cameraSpeed = 0.8f;

    void Update() {
        if (Globals.gameState == GameStates.notPlaying) {
            return;
        }
        transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
    }
}
