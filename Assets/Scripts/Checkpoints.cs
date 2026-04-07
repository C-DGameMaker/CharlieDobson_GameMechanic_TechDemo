using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

        }
    }

    
}
