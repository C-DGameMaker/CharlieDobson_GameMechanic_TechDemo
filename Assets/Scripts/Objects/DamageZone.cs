using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ServiceHubManager.Instance.playerController._playerHealth.TakeDamage(1);
        }
    }
}
