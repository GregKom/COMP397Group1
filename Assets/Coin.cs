using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coin_text;
    public PlayerStats p;
    // Start is called before the first frame update
    void Start()
    {
        coin_text.text = p.Coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coin_text.text = p.Coins.ToString();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            coin_text.text = p.Coins.ToString();
            p.Coins += 1;
        }
    }
}
