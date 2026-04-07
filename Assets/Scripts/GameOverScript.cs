using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] UIManager uiManager;
    private void Awake()
    {
        player = ServiceHubManager.Instance.playerController;
        uiManager = ServiceHubManager.Instance.UIManager;
    }

    public void ContinueButton()
    {
        player.Respawn();
        uiManager.ShowGameplayUI();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
