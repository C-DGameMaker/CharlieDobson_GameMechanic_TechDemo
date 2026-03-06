using UnityEngine;

/// <summary>
/// This will make the object rotate
/// </summary>
public class Rotator : MonoBehaviour
{
    public Vector3 _rotator = new Vector3(15, 30, 45);
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotator * Time.deltaTime);
    }
}
