using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*TestData testData = new TestData();
        testData.score = 1000;
        testData.coins = 150;
        string json = JsonUtility.ToJson(testData);
        File.WriteAllText(Application.dataPath + "/PlayerData/SaveData.dat", json);*/
        /*string json = File.ReadAllText(Application.dataPath + "/PlayerData/SaveData.dat");
        TestData loadedData = JsonUtility.FromJson<TestData>(json);
        print(loadedData.coins);
        print(loadedData.score);*/
    }

    private class TestData
    {
        public int score;
        public int coins;
    }
}
