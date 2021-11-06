using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] Player playerScript;
    
    private string path;

    private void Awake()
    {
        path = CheckPlatformPath();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerData pd = new PlayerData();
        pd.highestScore = playerScript.scoreScript.highestScore;
        if (pd.highestScore == 0)
            pd.coins = 0;
        else
            pd.coins = pd.highestScore / 2;
/*#if UNITY_ANDROID || UNITY_IOS
        print("Unity on Android or iOS on Start Func");
        path = Application.persistentDataPath + "/PlayerData/SaveData.dat";
#endif*/
/*#if UNITY_STANDALONE
        print("Unity on Desktop on Start Func");
        path = Application.dataPath + "/PlayerData/SaveData.dat";
#endif
#if UNITY_EDITOR
        print("Unity on Editor on Start Func");
        path = Application.dataPath + "/PlayerData/SaveData.dat";
#endif*/
        if (IsSaveFileExist())
        {
            PlayerData loadedPD = LoadData();
            playerScript.scoreScript.score = loadedPD.highestScore;
            playerScript.scoreScript.coins = loadedPD.coins;            
        }
        else
        {
            SaveData(pd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static string CheckPlatformPath()
    {
#if UNITY_EDITOR
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
