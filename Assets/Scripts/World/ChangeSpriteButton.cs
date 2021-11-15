using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeSpriteButton : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManagerScript;
    private AcquiredItemHolder acquiredItemHolderScript;
    private PlayerData pd = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(GetComponent<ChangeSpriteButton>().SelectSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectSprite()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        acquiredItemHolderScript = btn.GetComponent<AcquiredItemHolder>();
        string btnName = btn.GetComponent<AcquiredItemHolder>().GetAcquiredItem().GetName();
        if (acquiredItemHolderScript.GetAcquiredItem().GetName().Contains(btnName))
        {
            player.GetComponent<SpriteRenderer>().sprite = acquiredItemHolderScript.GetAcquiredItem().GetSprite();
            pd = gameManagerScript.gameUIScript.pd;
            pd.selectedSprite = player.GetComponent<SpriteRenderer>().sprite;
            gameManagerScript.saveSystemScript.SaveData(pd);
        }
    }
}
