using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Movement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;

    public AudioClip hurt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < transform.position.x)
        {
            rb.AddForce(-1, 0, 0, ForceMode.Force);
        }

        if (player.position.x > transform.position.x)
        {
            rb.AddForce(1, 0, 0, ForceMode.Force);
        }

        if (player.position.z < transform.position.z)
        {
            rb.AddForce(0, 0, -1, ForceMode.Force);
        }

        if (player.position.z > transform.position.z)
        {
            rb.AddForce(0, 0, 1, ForceMode.Force);
        }
    }
}
