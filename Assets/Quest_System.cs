using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAchievementObserver{
    void OnAchievementUnlocked(int achievementIndex);
}

public class Quest_System : MonoBehaviour{
    private List<IAchievementObserver> observers = new List<IAchievementObserver>();

    public float move;
    public int jumps;
    public int damage_taken;
    public bool wonBool = false;
    public PlayerStats player_stats;

    public bool hasAchievement1;
    public bool hasAchievement2;
    public bool hasAchievement3;
    public bool hasAchievement4;
    public bool hasAchievement5;

    public Text Quest_Text;
    public Text achievementsListText;

    void Start(){
        UpdateAchievementsListText();
    }

    void Update(){
        UpdateQuestText();
        CheckAchievements();
        
    }

    private void UpdateQuestText(){
        Quest_Text.text = "hello";

        if (!hasAchievement1 && !hasAchievement2 && !hasAchievement3 && !hasAchievement4 && !hasAchievement5){
            Quest_Text.text = "Use WASD to move.";
        }
        else if (hasAchievement1 && !hasAchievement2 && !hasAchievement3 && !hasAchievement4 && !hasAchievement5){
            Quest_Text.text = "Press Space to jump.";
        }
        else if (hasAchievement1 && hasAchievement2 && !hasAchievement3 && !hasAchievement4 && !hasAchievement5){
            Quest_Text.text = "Collect 3 coins on the platforms.";
        }
        else if (hasAchievement1 && hasAchievement2 && hasAchievement3 && !hasAchievement4 && !hasAchievement5){
            Quest_Text.text = "Take some damage by colliding with an enemy or a spike.";
        }
        else if (hasAchievement1 && hasAchievement2 && hasAchievement3 && hasAchievement4 && !hasAchievement5){
            Quest_Text.text = "Enter the purple square to win.";
        }
    }

    private void CheckAchievements(){
        if (!hasAchievement1 && move > 500){
            hasAchievement1 = true;
            NotifyObservers(1);
        }

        if (!hasAchievement2 && jumps > 5){
            hasAchievement2 = true;
            NotifyObservers(2);
        }

        if (!hasAchievement3 && player_stats.Coins > 2){
            hasAchievement3 = true;
            NotifyObservers(3);
        }

        if (!hasAchievement4 && damage_taken > 1){
            hasAchievement4 = true;
            NotifyObservers(4);
        }

        if (!hasAchievement5 && player_stats.wonBool){
            hasAchievement5 = true;
            NotifyObservers(5);
        }

        UpdateAchievementsListText();
    }

    public void AttachObserver(IAchievementObserver observer){
        observers.Add(observer);
    }

    public void DetachObserver(IAchievementObserver observer){
        observers.Remove(observer);
    }

    private void NotifyObservers(int achievementIndex){
        foreach (var observer in observers)
        {
            observer.OnAchievementUnlocked(achievementIndex);
        }
    }

    private void UpdateAchievementsListText(){
        string achievementsList = "";

        if (hasAchievement1){
            achievementsList = "- Walk around\n";
        }
        if (hasAchievement1 && hasAchievement2){
            achievementsList = "- Walk around\n- Jump up\n";
        }
        if (hasAchievement1 && hasAchievement2 && hasAchievement3){
            achievementsList = "- Walk around\n- Jump up\n- Collect coins\n";
        }
        if (hasAchievement1 && hasAchievement2 && hasAchievement3 && hasAchievement4){
            achievementsList = "- Walk around\n- Jump up\n- Collect coins\n- Won the game\n";
        }
        if (hasAchievement1 && hasAchievement2 && hasAchievement3 && hasAchievement4 && hasAchievement5){
            achievementsList = "- Walk around\n- Jump up\n- Collect coins\n- Took damage\n- Won the game\n";
        }

        achievementsListText.text = achievementsList;
    }
}
