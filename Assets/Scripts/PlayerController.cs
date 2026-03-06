using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] Vector2 _moveInput;


    private Rigidbody _playerRigidBody;

    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody>();

        if (_playerRigidBody == null) Debug.LogError("RigidBody not founded");

        ServiceHubManager.Instance.CountManager.SetCountText();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump()
    {
        if (Mathf.Abs(_playerRigidBody.linearVelocity.y) < 0.01f)
            _playerRigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y) * _movementSpeed * Time.deltaTime;
        _playerRigidBody.MovePosition(_playerRigidBody.position + move);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            ServiceHubManager.Instance.SFXManager.PickUpSound();
            ServiceHubManager.Instance.CountManager.AddCount();
            ServiceHubManager.Instance.CountManager.SetCountText();
            other.gameObject.SetActive(false);
        }
    }
}
