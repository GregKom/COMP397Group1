using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Slider health_slider;
    public int health_points;
    // Start is called before the first frame update
    void Start()
    {
        health_slider.value = health_points; 
    }

    // Update is called once per frame
    void Update()
    {
        health_slider.value = health_points;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            health_points -= 10;
        }
    }
}
