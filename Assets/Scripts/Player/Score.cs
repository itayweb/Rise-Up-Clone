using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] internal int score = 0;
    [SerializeField] internal int coins = 0;
    [SerializeField] Player playerScript;
    [SerializeField] Text scoreTxt;
    [SerializeField] internal bool startCounting = false;
    [SerializeField] internal int highestScore = 0;
 
    private float timer;
    private bool enableCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 1.5f;
        enableCooldown = false;
        scoreTxt.text = "";        
    }

    // Update is called once per frame
    void Update()
    {
        IncreasePoints();
        CheckHighestScore();
    }

    void IncreasePoints()
    {
        if (startCounting)
        {
            if (playerScript.playerMovementScript.isDead != true && !enableCooldown)
            {
                score++;
                scoreTxt.text = score.ToString();
                enableCooldown = true;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 1.5f;
                    enableCooldown = false;
                }
            }
        }
    }

    void CheckHighestScore()
    {
        if (highestScore < score)
            highestScore = score;
    }

    public int GetHighestScore()
    {
        return highestScore;
    }
}
