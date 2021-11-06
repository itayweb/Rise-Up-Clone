using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeSpriteButton : MonoBehaviour
{
    public GameObject player;
    private GameUI gameUIScript;
    private AcquiredItemHolder acquiredItemHolderScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GameObject gameManager = GameObject.Find("GameManager");
        gameUIScript = gameManager.GetComponent<GameUI>();
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
            print("Entered");
            player.GetComponent<SpriteRenderer>().sprite = acquiredItemHolderScript.GetAcquiredItem().GetSprite();
        }
    }
}
