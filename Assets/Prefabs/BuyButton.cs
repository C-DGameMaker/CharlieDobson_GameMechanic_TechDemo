using System.Diagnostics;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] GameplayUIManager coinCount;
    [SerializeField] TextMeshProUGUI text;

    private UIManager _uiManager;
    private PlayerController _playerController;
    void Start()
    {
        
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
