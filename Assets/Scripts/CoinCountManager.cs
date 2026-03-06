using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CoinCountManager : MonoBehaviour
{
    int _count;
    public TextMeshProUGUI _countText;
    void Start()
    {
        _count = 0;
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
