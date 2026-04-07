using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private UIManager _uiManager;
    private PlayerController _playerController;
    private GameplayUIManager _countManager;

    [SerializeField] Transform locationOutOfShop;
    [SerializeField] GameObject shopCamera;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject shopper;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] int Price1;
    [SerializeField] int Price2;

    private void Start()
    {
        _uiManager = ServiceHubManager.Instance.UIManager;
        _playerController = ServiceHubManager.Instance.playerController;
        _countManager = ServiceHubManager.Instance.GameplayUIManager;
        shopCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.ShowShopUI();
            playerCamera.SetActive(false);
            shopCamera.SetActive(true);
            text.text = "What do you want?";
            _playerController._canMove = false;
            shopper = other.gameObject;
        }
    }

    public void OnFirstButton()
    {
        if(_countManager._count >= Price1)
        {
            text.text = "Thank you for purchasing";
            _playerController._playerHealth.IncreaseMaxHealth(5);
            _countManager.SubtractCount(10);
        }
        else
        {
            text.text = "You don't have enough to buy.";
        }
    }

    public void OnBackButton()
    {
        shopper.transform.position = locationOutOfShop.position;
        playerCamera.SetActive(true);
        shopCamera.SetActive(false);
        _playerController._canMove = true;
        shopper = null;
        _uiManager.ShowGameplayUI();
    }

   

}
