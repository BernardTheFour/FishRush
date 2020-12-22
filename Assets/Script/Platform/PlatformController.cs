using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody myRB;

    public Transform LastPoint;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        myRB.velocity = transform.forward * SpeedController.Speed *-1;

        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
