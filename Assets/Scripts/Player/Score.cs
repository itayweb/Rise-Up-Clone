using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] internal int score = 0;
    [SerializeField] Player playerScript;
    [SerializeField] Text scoreTxt;
    [SerializeField] internal bool startCounting = false;
 
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10000;
        scoreTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        IncreasePoints();
    }

    void IncreasePoints()
    {
        if (startCounting)
        {
            if (playerScript.playerMovementScript.isDead != true && timer == 1)
            {
                score++;
                scoreTxt.text = score.ToString();
                print(score);
                timer = 10000;
            }

            timer /= 2;
        }
    }
}
