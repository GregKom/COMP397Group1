using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioClip jump;
    public AudioSource audioListener;
    public Rigidbody rb;
    public float xspeed;
    public float zspeed;
    // Start is called before the first frame update
    void Start()
    {
        audioListener = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(xspeed, 0, zspeed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xspeed = -1/16f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            xspeed = 1/16f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            zspeed = 1/16f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(xspeed, 10.0f, zspeed, ForceMode.Impulse);
            audioListener.PlayOneShot(jump, 1.0F);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            zspeed = -1/16f;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            zspeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            zspeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            xspeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            xspeed = 0;
        }
    }
}
