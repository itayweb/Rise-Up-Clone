using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasableItemHolder : MonoBehaviour
{
    [SerializeField] PurchasableItem purchasableItem;

    public PurchasableItem GetPurchasableItem()
    {
        return purchasableItem;
    }
}
