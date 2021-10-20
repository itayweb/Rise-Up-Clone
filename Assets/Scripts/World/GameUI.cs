using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject scoreLabelTxt;
    [SerializeField] GameObject scoreTxt;
    [SerializeField] SpriteRenderer player;
    [SerializeField] Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        player.color = new Color(player.color.r, player.color.g, player.color.b, player.color.a / 2);
        playerScript.scoreScript.startCounting = false;
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        scoreLabelTxt.SetActive(true);
        scoreTxt.SetActive(true);
        player.color = new Color(player.color.r, player.color.g, player.color.b, 255);
        playerScript.scoreScript.startCounting = true;
        Time.timeScale = 1;
    }
}
