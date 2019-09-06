using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{
    public string layer;
    public int order;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.sortingLayerName = layer;
        myMeshRenderer.sortingOrder = order;
    }
}
