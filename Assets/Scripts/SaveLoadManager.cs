using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public Vector3 playerPosition;
        public int playerHealth;
        public bool hasKey;
    }

    public GameObject player;

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerPosition = player.transform.position;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonData);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            player.transform.position = data.playerPosition;
        }
        else
        {
            player.transform.position = Vector3.zero;
        }
    }

    public void ClearSavedData()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
