using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    public float smoothSpeed = 5;


    private void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
        
        
}
