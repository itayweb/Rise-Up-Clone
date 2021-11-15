using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
    [SerializeField] internal int highestScore;
    [SerializeField] internal int coins;
    [SerializeField] internal List<string> itemsAcquired = new List<string>();
    [SerializeField] internal Sprite selectedSprite;
}
