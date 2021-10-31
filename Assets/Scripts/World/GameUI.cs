using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject scoreLabelTxt;
    [SerializeField] GameObject scoreTxt;
    [SerializeField] Text highestScoreTxt;
    [SerializeField] Text coinsMainMenuTxt;
    [SerializeField] Text coinsShopTxt;
    [SerializeField] SpriteRenderer playerRenderer;
    [SerializeField] Player playerScript;
    [SerializeField] Transform itemsContainer;

    private Button btn;
    private PlayerData pd = new PlayerData();
    private ItemHolder itemHolderScript;
    //private List<string> itemsAquired = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        CheckCoinsStatus(coinsMainMenuTxt);
        Time.timeScale = 0;
        FetchData();
        for (int i = 0; i < pd.itemsAquired.Count; i++)
        {
            int count = itemsContainer.childCount;
            for (int j = 0; j < count; j++)
            {
                if (pd.itemsAquired.Contains(itemsContainer.GetChild(j).gameObject.name))
                {
                    itemsContainer.GetChild(j).gameObject.GetComponent<Button>().interactable = false;

                }
            }
        }
        /*for (int i = 0; i < itemsAquired.Count; i++)
        {
            int count = itemsContainer.childCount;
            for (int j = 0; j < count; j++)
            {
                if (itemsAquired.Contains(itemsContainer.GetChild(i).gameObject.name))
                {
                    itemsContainer.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FetchData()
    {
        if (File.Exists(Application.dataPath + "/PlayerData/SaveData.dat"))
        {
            pd = playerScript.saveSystemScript.LoadData();
        }
    }

    void CheckCoinsStatus(Text coins)
    {
        if (File.Exists(Application.dataPath + "/PlayerData/SaveData.dat"))
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

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, playerRenderer.color.a / 2);
        playerScript.scoreScript.startCounting = false;
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        scoreLabelTxt.SetActive(true);
        scoreTxt.SetActive(true);
        playerRenderer.color = new Color(playerRenderer.color.r, playerRenderer.color.g, playerRenderer.color.b, 255);
        playerScript.scoreScript.startCounting = true;
        Time.timeScale = 1;
    }

    public void GoShop()
    {
        CheckCoinsStatus(coinsShopTxt);
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void BuyItem()
    {
        print(EventSystem.current.currentSelectedGameObject.name);
        //btn.name = EventSystem.current.currentSelectedGameObject.name;
        btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        itemHolderScript = EventSystem.current.currentSelectedGameObject.GetComponent<ItemHolder>();
        pd = playerScript.saveSystemScript.LoadData();
        int itemPrice = itemHolderScript.GetItem().GetPrice();
        if (pd.coins >= itemPrice)
        {
            btn.interactable = false;
            pd.coins -= itemPrice;
            pd.itemsAquired.Add(itemHolderScript.GetItem().GetName());
            playerScript.saveSystemScript.SaveData(pd);
            coinsShopTxt.text = pd.coins.ToString();
        }
        else
        {
            print("Insufficient coins");
        }
    }

    public void GoMainMenu()
    {
        CheckCoinsStatus(coinsMainMenuTxt);
        mainMenuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
}
