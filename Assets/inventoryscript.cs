using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryscript : MonoBehaviour
{
    public Canvas myInventoryCanvas;
    public int IsShowing = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            IsShowing *= -1;
        }

        if (IsShowing == -1)
        {
            myInventoryCanvas.enabled = false;
        }

        if (IsShowing == 1)
        {
            myInventoryCanvas.enabled = true;
        }
    }
}
