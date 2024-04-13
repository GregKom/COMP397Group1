using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest_System : MonoBehaviour
{
    public PlayerMovementController p;

    public float move;
    public int jumps;
    public int damage_taken;
    
    public bool hasAchievement1;
    public bool hasAchievement2;
    public bool hasAchievement3;
    public bool hasAchievement4;
    public bool hasAchievement5;

    public Text Achievement_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Achievement_Text.text = "hello";

        if (hasAchievement1 == false && hasAchievement2 == false && hasAchievement3 == false && hasAchievement4 == false && hasAchievement5 == false)
        {
            Achievement_Text.text = "Use WASD to move.";
        }

        if (hasAchievement1 == true && hasAchievement2 == false && hasAchievement3 == false && hasAchievement4 == false && hasAchievement5 == false)
        {
            Achievement_Text.text = "Press Space to jump.";
        }

        if (hasAchievement1 == true && hasAchievement2 == true && hasAchievement3 == false && hasAchievement4 == false && hasAchievement5 == false)
        {
            Achievement_Text.text = "Press Space to jump 5 more times.";
        }

        if (hasAchievement1 == true && hasAchievement2 == true && hasAchievement3 == true && hasAchievement4 == false && hasAchievement5 == false)
        {
            Achievement_Text.text = "Use WASD to move some more.";
        }

        if (hasAchievement1 == true && hasAchievement2 == true && hasAchievement3 == true && hasAchievement4 == true && hasAchievement5 == false)
        {
            Achievement_Text.text = "Take some damage by colliding with an enemy or a spike.";
        }


        if (move > 2000)
        {
            hasAchievement1 = true;
        }

        if (jumps > 0)
        {
            hasAchievement2 = true;
        }

        if (jumps > 5)
        {
            hasAchievement3 = true;
        }

        if (move > 5000)
        {
            hasAchievement4 = true;
        }

        if (damage_taken > 1)
        {
            hasAchievement5 = true;
        }
    }
}
