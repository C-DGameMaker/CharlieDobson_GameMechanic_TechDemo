using TMPro;
using UnityEngine;

/// <summary>
/// Displays the inGameUI
/// </summary>
public class GameplayUIManager : MonoBehaviour
{
    private int _count;
    public TextMeshProUGUI _countText;
    public TextMeshProUGUI _healthText;
    void Start()
    {
        _count = 0;
    }

    public void SetHealthText()
    {
        _healthText.text = "Health: " + ServiceHubManager.Instance.playerController._playerHealth.CurrentHealth.ToString() + " / "+ ServiceHubManager.Instance.playerController._playerHealth.MaxHealth.ToString();
    }
    public void SetCountText()
    {
        _countText.text = "Count: " + _count.ToString();
    }

    public void AddCount()
    {
        _count++;
    }
}
