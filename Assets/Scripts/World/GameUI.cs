using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Linq;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject itemsPanel;
    [SerializeField] private GameObject scoreLabelTxt;
    [SerializeField] private GameObject scoreTxt;
    [SerializeField] private Text highestScoreTxt;
    [SerializeField] private Text coinsMainMenuTxt;
    [SerializeField] private Text coinsShopTxt;
    [SerializeField] private SpriteRenderer playerRenderer;
    [SerializeField] private Player playerScript;
    [SerializeField] private Transform itemsContainer;
    [SerializeField] private List<GameObject> itemsList = new List<GameObject>();
    [SerializeField] private GameObject itemsAcquiredContainer;
    [SerializeField] private List<Sprite> playerSprites = new List<Sprite>();

    private Button btn;
    private PlayerData pd = new PlayerData();
    private PurchasableItemHolder purchasableItemHolderScript;

    // Start is called before the first frame update
    private void Start()
    {
        CheckCoinsStatus(coinsMainMenuTxt);
        Time.timeScale = 0;
        FetchData();
        UpdateShopButtons();
        UpdateAcquiredButtons();
        //AssignButtons();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    
    private void AssignButtons()
    {
        Button[] btns = itemsContainer.GetComponentsInChildren<Button>();
        for (int i = 0; i < btns.Length; i++)
        {
            print("found");
            btns[i].onClick.AddListener((UnityEngine.Events.UnityAction)SelectPlayerSprite);
        }
    }

    private void UpdateAcquiredButtons() // Updating the acquired items in the items panel to be visible
    {
        if (playerScript.saveSystemScript.IsSaveFileExist())
        {
            pd = playerScript.saveSystemScript.LoadData();
            var itemsAcquiredList = pd.itemsAcquired;
            if (itemsAcquiredList.Any())
            {
                for (int i = 0; i < itemsAcquiredList.Count; i++)
                {
                    for (int j = 0; j < itemsList.Count; j++)
                    {
                        string btnName = itemsList[j].GetComponent<AcquiredItemHolder>().GetAcquiredItem().GetName();
                        if (itemsAcquiredList[i].Contains(btnName))
                        {
                            Instantiate(itemsList[j], itemsAcquiredContainer.transform, false).GetComponent<Button>();
                        }
                    }
                }
            }
            else
            {
                print("No items has acquired!");
            }
        }
        else
        {
            print("No save file has found!");
        }
    }

    private void UpdateShopButtons() // Updating the acquired items in the shop to be disabled
    {
        for (int i = 0; i < pd.itemsAcquired.Count; i++)
        {
            int count = itemsContainer.childCount;
            for (int j = 0; j < count; j++)
            {
                if (pd.itemsAcquired.Contains(itemsContainer.GetChild(j).gameObject.name))
                {
                    itemsContainer.GetChild(j).gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    private void FetchData() // Fetching player data from player's local save file
    {
        if (playerScript.saveSystemScript.IsSaveFileExist())
        {
            pd = playerScript.saveSystemScript.LoadData();
        }
    }

    private void CheckCoinsStatus(Text coins) // Updating player's coins stats
    {
        if (playerScript.saveSystemScript.IsSaveFileExist())
        {
            pd = playerScript.saveSystemScript.LoadData();
            highestScoreTxt.text = pd.highestScore.ToString();
            coins.text = pd.coins.ToString();
        }
        else
        {
            highestScoreTxt.text = "0";
            coins.text = "0";
        }
    }

    public void RestartGame() // Restarting the game (Controlled by other script)
    {
        SceneManager.LoadScene("Game");
        playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, playerRenderer.color.a / 2);
        playerScript.scoreScript.startCounting = false;
    }

    public void PlayGame() // Playing the game when the player pressing the play button
    {
        mainMenuPanel.SetActive(false);
        scoreLabelTxt.SetActive(true);
        scoreTxt.SetActive(true);
        playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, 255);
        playerScript.scoreScript.startCounting = true;
        Time.timeScale = 1;
    }

    public void GoItems()
    {
        CheckCoinsStatus(coinsShopTxt);
        mainMenuPanel.SetActive(false);
        itemsPanel.SetActive(true);
    }

    public void SelectPlayerSprite()
    {
        btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        purchasableItemHolderScript = EventSystem.current.currentSelectedGameObject.GetComponent<PurchasableItemHolder>();
        for (int i = 0; i < playerSprites.Count; i++)
        {
            if (purchasableItemHolderScript.GetPurchasableItem().GetName().Contains(playerSprites[i].name))
            {
                Sprite selectedSprite = playerSprites[i];
                playerRenderer.sprite = selectedSprite;
            }
        }
    }
    
    public void GoShop() // Changing panels when player press the shop button
    {
        CheckCoinsStatus(coinsShopTxt);
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void BuyItem() // Checking player's coins stats, and which item button pressed - decreasing coins stats and adding the item name to the saving data list
    {
        print(EventSystem.current.currentSelectedGameObject.name);
        btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        purchasableItemHolderScript = EventSystem.current.currentSelectedGameObject.GetComponent<PurchasableItemHolder>();
        FetchData();
        int itemPrice = purchasableItemHolderScript.GetPurchasableItem().GetPrice();
        if (pd.coins >= itemPrice)
        {
            btn.interactable = false;
            pd.coins -= itemPrice;
            pd.itemsAcquired.Add(purchasableItemHolderScript.GetPurchasableItem().GetName());
            string btnName = purchasableItemHolderScript.GetPurchasableItem().GetName();
            for (int i = 0; i < itemsList.Count; i++)
            {
                string currentButtonName = itemsList[i].GetComponent<PurchasableItemHolder>().GetPurchasableItem().GetName();
                if (currentButtonName.Contains(btnName))
                {
                    Instantiate(itemsList[i], itemsAcquiredContainer.transform, false);
                }
            }
            playerScript.saveSystemScript.SaveData(pd);
            coinsShopTxt.text = pd.coins.ToString();
        }
        else
        {
            print("Insufficient coins");
        }
    }

    public void GoMainMenuFromShop() // Changing panels when player decide to go back whether from shop or items panel
    {
        CheckCoinsStatus(coinsMainMenuTxt);
        mainMenuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void GoMainMenuFromItems()
    {
        CheckCoinsStatus(coinsMainMenuTxt);
        mainMenuPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }
}
