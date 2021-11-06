using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquiredItemHolder : MonoBehaviour
{
    [SerializeField] private AcquiredItem acquiredItem;

    public AcquiredItem GetAcquiredItem()
    {
        return acquiredItem;
    }
}
