using System;
using TMPro;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public string playerName;
    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.loadedLevelName == "menu")
        {
            TextMeshProUGUI bestScoreText = GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            bestScoreText.text = "Best Score: " + bestScore;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            playerName = data.playerName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string playerName;
    }
}
