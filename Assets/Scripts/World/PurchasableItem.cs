using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Purchasable Item", menuName = "Purchasable Item")]
public class PurchasableItem : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField] int price;

    public int GetPrice()
    {
        return price;
    }

    public string GetName()
    {
        return name;
    }
}
