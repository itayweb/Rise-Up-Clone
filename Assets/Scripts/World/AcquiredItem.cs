using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Acquired Item", menuName = "Acquired Item")]
public class AcquiredItem : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private Sprite sprite;
    
    public string GetName()
    {
        return name;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}
