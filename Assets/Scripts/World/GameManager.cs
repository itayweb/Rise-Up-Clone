using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal SaveSystem saveSystemScript;
    [SerializeField] internal LevelGenerator levelGeneratorScript;
    [SerializeField] internal GameUI gameUIScript;
    [SerializeField] internal Player playerScript;
    
    // Start is called before the first frame update
    void Awake()
    {
        //playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        /*saveSystemScript = GetComponent<SaveSystem>();
        gameUIScript = GetComponent<GameUI>();*/
        //playerScript = GameObject.Find("Player").GetComponent<Player>();
        //levelGeneratorScript = GetComponent<LevelGenerator>();
    }
}
