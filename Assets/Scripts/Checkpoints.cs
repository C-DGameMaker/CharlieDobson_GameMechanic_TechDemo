using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Renderer objRenderer;
    [SerializeField] private Color gottenColor;
    [SerializeField] private PlayerController respawnLocation;

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>();
        respawnLocation = ServiceHubManager.Instance.playerController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objRenderer.material.color = gottenColor;
            respawnLocation.currentRespawnLocation = respawnPoint;
        }
    }

    
}
