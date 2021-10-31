using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item")]
public class Item : ScriptableObject
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
