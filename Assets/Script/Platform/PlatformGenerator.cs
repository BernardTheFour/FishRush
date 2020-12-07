using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private List<Platform> Variant = null;

    private float value;
    private Vector3 SummonPosition;
    public bool Spawn = false;

    private void Awake()
    {
        SummonPosition = gameObject.transform.position;
        SummonPosition.y = 0f;
    }

    private void Start()
    {
        float value = 0;
        foreach (Platform platform in Variant)
        {
            value += platform.Probability;
            platform.CumulativeProbability = value;
        }
    }

    private void Update()
    {
        if (Spawn)
        {
            Create();
        }
    }

    public void Create()
    {
        float value = Random.value;

        foreach(Platform platform in Variant)
        {
            if (value <= platform.CumulativeProbability)
            {
                Debug.Log("Summon: " + platform.Name);
                Spawn = false;
                break;
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("River"))
    //    {
    //        Create();
    //    }
    //}
}
