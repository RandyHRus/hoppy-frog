using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropShadow : MonoBehaviour
{
    private float offset = 0.07f;
    public Material Material;
    GameObject shadow;


    private void Start()
    {
        shadow = new GameObject("Shadow");
        shadow.transform.parent = transform;

        shadow.transform.localPosition = new Vector2(transform.position.x, transform.position.y - offset);
        shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = Material;
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 10;
    }

    void LateUpdate()
    {
        shadow.transform.position = new Vector2(transform.position.x, transform.position.y - offset);
    }

}
