using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PusherCharacter : MonoBehaviour
{
    [SerializeField] GameObject _pushee;
    [SerializeField] float _movementSpeed;
    private Rigidbody _followerRigidbody;

    private void Start()
    {

        _followerRigidbody = GetComponent<Rigidbody>();
        if (_followerRigidbody == null)
        {
            Debug.Log("WHERE IS THE RIGIDBODY MICHAEL?! WHERE IS IT?! WHAT DID YOU DO TO IT MICHAEL");
        }
    }

    private void Update()
    {
        Vector3 lookDirection = (_pushee.transform.position - transform.position).normalized;

        _followerRigidbody.AddForce(lookDirection * _movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Pusher") && !other.CompareTag("Coin"))
        {
            _pushee = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        _pushee = null;
    }
}
