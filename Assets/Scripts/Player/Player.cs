using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal PlayerMovement playerMovementScript;
    [SerializeField] internal Score scoreScript;
    [SerializeField] internal GameManager gameManagerScript;

    // Start is called before the first frame update
    void Awake()
    {
        /*scoreScript = GetComponent<Score>();
        playerMovementScript = GetComponent<PlayerMovement>();*/
        //gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
