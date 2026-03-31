using System.Security.Cryptography;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameplayUI;
    [SerializeField] GameObject _pausedUI;
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] GameObject _shopUI;

    private void HideAllUI()
    {
        _gameplayUI.SetActive(false);
        _pausedUI.SetActive(false);
        _gameOverUI.SetActive(false);
        _shopUI.SetActive(false);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();

        _gameplayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        HideAllUI();
        _gameplayUI.SetActive(true);
        _pausedUI.SetActive(true);
    }

    public void ShowShopUI()
    {
        HideAllUI();
        _gameplayUI.SetActive(true);
        _shopUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        HideAllUI();
        _gameOverUI.SetActive(true);
    }

}
