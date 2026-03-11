using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PusherCharacter : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _movementSpeed;
    private Rigidbody _followerRigidbody;

    private void Start()
    {
        if (_player == null)
        {
            Debug.Log("Add player to follow");
        }

        _followerRigidbody = GetComponent<Rigidbody>();
        if (_followerRigidbody == null)
        {
            Debug.Log("WHERE IS THE RIGIDBODY MICHAEL?! WHERE IS IT?! WHAT DID YOU DO TO IT MICHAEL");
        }
    }

    private void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;

        _followerRigidbody.AddForce(lookDirection * _movementSpeed);
    }
}
