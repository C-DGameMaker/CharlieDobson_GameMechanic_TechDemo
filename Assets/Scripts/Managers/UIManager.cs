using System.Security.Cryptography;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameplayUI;
    [SerializeField] GameObject _pausedUI;

    private void HideAllUI()
    {
        _gameplayUI.SetActive(false);
        _pausedUI.SetActive(false);
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

}
