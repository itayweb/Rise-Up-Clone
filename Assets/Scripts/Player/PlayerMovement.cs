using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Player playerScript;
    [SerializeField] internal bool isDead = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(0, moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPlayerState"))
        {
            playerScript.gameManagerScript.levelGeneratorScript.canGenerate = true;
        }

        if (collision.CompareTag("Props"))
        {
            isDead = true;
            PlayerData loadedPD = playerScript.gameManagerScript.saveSystemScript.LoadData();
            loadedPD.highestScore = playerScript.scoreScript.GetHighestScore();
            loadedPD.coins += (playerScript.scoreScript.score / 2);
            loadedPD.selectedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            loadedPD.itemsAcquired = loadedPD.itemsAcquired;
            playerScript.gameManagerScript.saveSystemScript.SaveData(loadedPD);
            playerScript.gameManagerScript.gameUIScript.RestartGame();
        }
    }
}
