using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_inventory_pool : MonoBehaviour
{
    public Inventory i;
    public int pool_items;
    public GameObject bullets;
    // Start is called before the first frame update
    void Start()
    {
        pool_items = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && i.Bullets > 0)
        {
            i.Bullets -= 1;
            pool_items += 1;
            GameObject bullet = Instantiate(bullets);
        }
    }
}
