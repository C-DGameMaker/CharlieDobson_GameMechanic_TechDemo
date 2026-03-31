using UnityEngine;

public class Shop : MonoBehaviour
{
    private UIManager _uiManager;
    private PlayerController _playerController;

    private void Start()
    {
        _uiManager = ServiceHubManager.Instance.UIManager;
        _playerController = ServiceHubManager.Instance.playerController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.ShowShopUI();
            _playerController._canMove = false;
        }
    }
}
