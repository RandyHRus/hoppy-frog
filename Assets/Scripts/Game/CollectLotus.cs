using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLotus : MonoBehaviour
{
    private int count;

    private static CollectLotus _instance;

    public static CollectLotus Instance { get { return _instance; } }


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

    private void Start()
    {
        UI.Instance.ChangeLotusCount(count);
    }

    public void GainLotus(GameObject lotus)
    {
        Object.Destroy(lotus);
        count++;
        UI.Instance.GainLotus();
        UI.Instance.ChangeLotusCount(count);
        lotus.transform.parent.GetComponent<Lily>().SetLotus(false);
    }

    public int GetCount()
    {
        return count;
    }

    public void SetCount(int num)
    {
        count = num;
    }
}
