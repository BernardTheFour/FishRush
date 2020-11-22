/* I think this code is too long,
 * But i dont know how to make it simple, yet still efficient
 * 
 * The idea is to pool it inside the different cup (type) of gameobject
 * so when we wants to find a certain platform with a certain cup,
 * we wont be doing a search for full iteration,
 * just give the cup and find what platform is currently free
 * */

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

    public Platform pooledObject;
    public Platform objectToPool;
    [SerializeField] private int CopyAmount = 5;

    private void Start()
    {
        pooledObject = new Platform();
        GameObject currentObj;

        foreach (GameObject obj in objectToPool.NoObsVariant)
        {
            for (int i = 0; i < CopyAmount; i++)
            {
                currentObj = Instantiate(obj);
                currentObj.SetActive(false);
                pooledObject.NoObsVariant.Add(currentObj);
            }
        }

        foreach (GameObject obj in objectToPool.ObsVariant)
        {
            for (int i = 0; i < CopyAmount; i++)
            {
                currentObj = Instantiate(obj);
                currentObj.SetActive(false);
                pooledObject.ObsVariant.Add(currentObj);
            }
        }

        foreach (GameObject obj in objectToPool.NoJumpVariant)
        {
            for (int i = 0; i < CopyAmount; i++)
            {
                currentObj = Instantiate(obj);
                currentObj.SetActive(false);
                pooledObject.NoJumpVariant.Add(currentObj);
            }
        }

        foreach (GameObject obj in objectToPool.BonusVariant)
        {
            for (int i = 0; i < CopyAmount; i++)
            {
                currentObj = Instantiate(obj);
                currentObj.SetActive(false);
                pooledObject.BonusVariant.Add(currentObj);
            }
        }
    }

    public GameObject GetPooledObject(Platform.Types type)
    {
        switch (type)
        {
            case Platform.Types.NoObsVariant:
                foreach (GameObject obj in pooledObject.NoObsVariant)
                {
                    if (!obj.activeInHierarchy)
                    {
                        return obj;
                    }
                }
                break;
            case Platform.Types.ObsVariant:
                foreach (GameObject obj in pooledObject.ObsVariant)
                {
                    if (!obj.activeInHierarchy)
                    {
                        return obj;
                    }
                }
                break;
            case Platform.Types.NoJumpVariant:
                foreach (GameObject obj in pooledObject.NoJumpVariant)
                {
                    if (!obj.activeInHierarchy)
                    {
                        return obj;
                    }
                }
                break;
            case Platform.Types.BonusVariant:
                foreach (GameObject obj in pooledObject.BonusVariant)
                {
                    if (!obj.activeInHierarchy)
                    {
                        return obj;
                    }
                }
                break;
        }

        return null;
    }
}
