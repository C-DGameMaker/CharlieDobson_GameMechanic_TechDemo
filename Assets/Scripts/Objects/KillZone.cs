using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ServiceHubManager.Instance.playerController._playerHealth.TakeDamage(9999);
        }
    }
}
