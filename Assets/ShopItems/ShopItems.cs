using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item")]
public class ShopItems : ScriptableObject
{
    public string itemID;
    public string itemTitle;
    public string itemDescription;
    public int itemCost;

    public void OnEnable()
    {
        if (string.IsNullOrEmpty(itemID))
        {
            itemID = itemID + Guid.NewGuid().ToString();
        }
    }
}
