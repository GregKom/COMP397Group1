using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject player;

    public void SaveGame()
    {
        Vector3 playerPosition = player.transform.position;

        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);
        PlayerPrefs.Save();
    }

public void LoadGame()
{
    if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
    {
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");

        player.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
    }
    else
    {
        player.transform.position = Vector3.zero;
    }
}

    public void ClearSavedData()
    {
        PlayerPrefs.DeleteAll();
    }
}
