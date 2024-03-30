using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public item_inventory_pool iip;
    public bool isGoing;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isGoing = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iip.pool_items > 0 && Input.GetKeyDown(KeyCode.F))
        {
            iip.pool_items -= 1;
            isGoing = true;
        }

        if (isGoing == false)
        {
            rb.AddForce(0, 0, 0, ForceMode.Force);
        }

        if (isGoing == true)
        {
            rb.AddForce(0, 0, 100, ForceMode.Force);
        }
    }
}
