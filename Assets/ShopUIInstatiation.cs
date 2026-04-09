using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUIInstatiation : MonoBehaviour
{
    public ShopItems shopItem;
    public GameObject shopDisplayPrefab;
    public Transform parent;

    private void Start()
    {
        if(shopDisplayPrefab == null || shopItem == null)
        {
            Debug.LogError("Array of items or Prefab not assigned!");
            return;
        }

        GameObject shopItemInstance = Instantiate(shopDisplayPrefab, parent);
        TextMeshProUGUI ShopDisplayText = shopItemInstance.GetComponentInChildren<TextMeshProUGUI>();
        if(ShopDisplayText != null)
        {
            ShopDisplayText.text = shopItem.itemDescription + " | " + shopItem.itemCost.ToString();
        }
    }

}
