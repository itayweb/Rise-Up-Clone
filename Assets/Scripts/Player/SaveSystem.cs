using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] internal GameManager gameManagerScript;
    [SerializeField] private Sprite defaultPlayerSprite;
    
    private string path;

    private void Awake()
    {
        gameManagerScript = GetComponent<GameManager>();
        path = CheckPlatformPath();
        if (IsSaveFileExist())
        {
            PlayerData loadedPD = LoadData();
            gameManagerScript.playerScript.scoreScript.highestScore = loadedPD.highestScore;
            gameManagerScript.playerScript.scoreScript.coins = loadedPD.coins;
            if (loadedPD.selectedSprite != null)
                gameManagerScript.playerScript.GetComponent<SpriteRenderer>().sprite = loadedPD.selectedSprite;
            else
            {
                gameManagerScript.playerScript.GetComponent<SpriteRenderer>().sprite = defaultPlayerSprite;
            }
        }
        else
        {
            PlayerData pd = new PlayerData();
            pd.highestScore = 0;
            pd.coins = 0;
            SaveData(pd);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*PlayerData pd = new PlayerData();
        pd.highestScore = gameManagerScript.playerScript.scoreScript.highestScore;
        if (pd.highestScore == 0)
            pd.coins = 0;
        else
            pd.coins = pd.highestScore / 2;
        if (IsSaveFileExist())
        {
            PlayerData loadedPD = LoadData();
            gameManagerScript.playerScript.scoreScript.score = loadedPD.highestScore;
            gameManagerScript.playerScript.scoreScript.coins = loadedPD.coins;
            if (loadedPD.selectedSprite != null)
                gameManagerScript.GetComponent<SpriteRenderer>().sprite = loadedPD.selectedSprite;
            else
            {
                gameManagerScript.GetComponent<SpriteRenderer>().sprite = defaultPlayerSprite;
            }
        }
        else
        {
            SaveData(pd);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static string CheckPlatformPath()
    {
#if UNITY_ANDROID || UNITY_IOS
        print("Unity on Android or iOS on Start Func");
        return Application.persistentDataPath + "/SaveData.dat";
#endif
#if UNITY_EDITOR || UNITY_STANDALONE
        return Application.dataPath + "/PlayerData/SaveData.dat";
#endif
    }

    public bool IsSaveFileExist()
    {
        return (File.Exists(path));
    }

    public void SaveData(PlayerData pd)
    {
        string json = JsonUtility.ToJson(pd);
        File.WriteAllText(path, json);
    }

    public PlayerData LoadData()
    {
        string json;
        print("Unity on Editor on LoadData Func");
        json = File.ReadAllText(path);
        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);        
        return loadedData;
    }
}
