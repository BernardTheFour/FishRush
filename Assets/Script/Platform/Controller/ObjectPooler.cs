using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public List<GameObject> pooledObjects = null;
    public List<GameObject> objectToPool = null;
    public int amountToPool;

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach(GameObject obj in objectToPool)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject instObj = (GameObject)Instantiate(obj);
                instObj.SetActive(false);
                pooledObjects.Add(instObj);
            }
        }
    }
}
