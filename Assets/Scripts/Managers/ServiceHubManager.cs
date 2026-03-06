using UnityEngine;


[DefaultExecutionOrder(-100)]
public class ServiceHubManager : MonoBehaviour
{
    public static ServiceHubManager Instance { get; private set; }


    [Header("System References")]
    public PlayerController playerController;
    public SFXManager SFXManager;
    public GameplayUIManager GameplayUIManager;
    public UIManager UIManager;
    public GameStateManager GameStateManager;

    private void Awake()
    {
        #region Singleton Pattern

        // Simple singleton setup for a single-scene game
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        #endregion
    }
}
