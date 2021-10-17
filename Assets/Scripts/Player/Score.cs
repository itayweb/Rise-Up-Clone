using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] internal int score = 0; // AKA Distance or Points
    [SerializeField] Player playerScript;
    [SerializeField] float cooldownSeconds;

    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp = Time.time + cooldownSeconds;
        IncreasePoints();
    }

    void IncreasePoints()
    {
        while (playerScript.playerMovementScript.isDead != true && timeStamp <= Time.time)
        {
            score++;
            print(score);
        }
    }
}
