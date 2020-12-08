using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private List<Platform> Variant = null;

    public Transform LastPlatform;
    public bool Spawn = false;

    private void Awake()
    {

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
        if(LastPlatform.position.z <= transform.position.z)
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
                //Debug.Log("Summon: " + platform.Name);
                int randomValue = Random.Range(0, platform.Platforms.Count - 1);
                GameObject gameObject = Instantiate(platform.Platforms[randomValue], LastPlatform.position, Quaternion.identity);
                LastPlatform = gameObject.GetComponent<PlatformController>().LastPoint;
                Spawn = false;
                break;
            }
        }
    }
}
