using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

[System.Serializable]
public class GameScore
{
    public List<LevelScore> levelScores;
    public int solider1;
    public int solider2;
    public int solider3;
}

[System.Serializable]
public class LevelScore
{
    public int level;
    public int coin;
    public int soSao;
}





public class SavingFile : MonoBehaviour
{
    private static SavingFile instance;
    public static SavingFile Instance { get => instance; set => instance = value; }

    public GameScore gameScore;
    public int level;
    public int coin;
    public int soSao;
    public static int solider1;
    public static int solider2;
    public static int solider3;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
            LoadData();
        SavingFile.instance = this;
        solider1 = gameScore.solider1;
        solider2 = gameScore.solider2;
        solider3 = gameScore.solider3;
        
    }

    private void Update()
    {
        if (solider1 != gameScore.solider1 || solider2 != gameScore.solider2 || solider3 != gameScore.solider3)
        {
            Debug.Log("Save :");
            Save(level,coin,soSao);
            SaveSolider(solider1,solider2,solider3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Load(level);
        }
    }
    public void LoadData()
    {
        string file = "save.json";
        string filePath = Path.Combine(Application.persistentDataPath, file);

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
        gameScore = JsonUtility.FromJson<GameScore>(File.ReadAllText(filePath));
        Debug.Log("Load Done!");
    }

    public void SaveData()
    {
        string file = "save.json";
        string filePath = Path.Combine(Application.persistentDataPath, file);

        string json = JsonUtility.ToJson(gameScore,true);

        File.WriteAllText(filePath, json);

        Debug.Log("File, save, at path: " + filePath);
    }

    public void Save(int level, int coin,int soSao)
    {
        foreach(var levelScore  in gameScore.levelScores) 
        {
           
            if(levelScore.level == level)
            {   levelScore.coin = coin;
                if(levelScore.soSao < soSao) levelScore.soSao = soSao;

                SaveData();
                return;
            }
            
        }
                
            LevelScore lScore = new LevelScore();
            lScore.level = level;
            lScore.coin = coin;
        lScore.soSao = soSao;

            gameScore.levelScores.Add(lScore);
            SaveData();

    }
    public void SaveSolider(int solider1, int solider2, int solider3)
    {
            gameScore.solider1 = solider1;
            gameScore.solider2 = solider2;
            gameScore.solider3 = solider3;

            SaveData();



    }
    public void Load(int level)
    {
        foreach (var levelScore in gameScore.levelScores)
        {
            if( levelScore.level == level)
            {
                Debug.Log("Load level sore: " + level + " " + levelScore.coin);
                return;
            }
        }
        Debug.Log("Load level sore: " + level + " " + 0);

    }
}
