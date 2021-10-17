using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] levelsTemplates;
    [SerializeField] Color[] backgroundColors;
    [SerializeField] GameObject player;
    [SerializeField] internal bool canGenerate = false;
    [SerializeField] Camera playerCamera;

    private int rndLevelSelector;
    private int rndBackgroundColorNum;
    private Color rndBackgroundColor;
    private GameObject level;    

    // Start is called before the first frame update
    void Start()
    {
        level = player;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateLevels();
    }

    void GenerateLevels()
    {
        
        if (canGenerate)
        {
            if (level.transform.position.y < player.transform.position.y)
            {
                Destroy(level);
            }
            rndLevelSelector = Random.Range(0, levelsTemplates.Length);
            level = Instantiate(levelsTemplates[rndLevelSelector]) as GameObject;
            Vector2 newLevel = new Vector2(player.transform.position.x, player.transform.position.y + 5);
            level.transform.position = newLevel;
            rndBackgroundColorNum = Random.Range(0, backgroundColors.Length);
            rndBackgroundColor = backgroundColors[rndBackgroundColorNum];
            playerCamera.backgroundColor = rndBackgroundColor;
            canGenerate = false;
        }
    }
}
