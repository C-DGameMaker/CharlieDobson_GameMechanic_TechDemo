using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private UIManager _uiManager;
    private PlayerController _playerController;

    [SerializeField] Transform locationOutOfShop;
    [SerializeField] GameObject shopCamera;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject shopper;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        _uiManager = ServiceHubManager.Instance.UIManager;
        _playerController = ServiceHubManager.Instance.playerController;
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

    public void OnBackButton()
    {
        StartCoroutine(EndShopping());
        shopper.transform.position = locationOutOfShop.position;
        playerCamera.SetActive(true);
        shopCamera.SetActive(false);
        _playerController._canMove = true;
        shopper = null;
        _uiManager.ShowGameplayUI();
    }

    IEnumerator EndShopping()
    {
        text.text = "Thank you! Come again!";
        yield return new WaitForSeconds(50f);
    }

}
