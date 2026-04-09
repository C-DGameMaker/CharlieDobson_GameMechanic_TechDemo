using System.Collections;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIInstatiation : MonoBehaviour
{
    public ShopItems shopItem;
    public GameObject shopDisplayPrefab;
    public Transform parent;
    [SerializeField] int price;
    [SerializeField] GameplayUIManager coinCount;
    [SerializeField] TextMeshProUGUI text;

    private UIManager _uiManager;
    private PlayerController _playerController;


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

        Button buyButton = shopItemInstance.GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(ButtonToBuy);

        coinCount = ServiceHubManager.Instance.GameplayUIManager;
        price = shopItem.itemCost;

        _uiManager = ServiceHubManager.Instance.UIManager;
        _playerController = ServiceHubManager.Instance.playerController;
    }

    public void ButtonToBuy()
    {
        if (coinCount._count >= price)
        {
            text.text = "Thank you for purchasing";
            _playerController._playerHealth.IncreaseMaxHealth(5);
            coinCount.SubtractCount(10);
        }
        else
        {
            text.text = "You don't have enough to buy.";
        }
    }


}
