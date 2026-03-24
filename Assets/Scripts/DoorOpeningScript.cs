using System.Collections;
using UnityEngine;

public class DoorOpeningScript : MonoBehaviour
{
    [SerializeField] float _doorOpeningSpeed;

    [SerializeField] Transform _doorTransform;

    private float doorAngle = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(PlayDoorOpeningSequence());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(PlayDoorClosingSequence());
        }
    }

    IEnumerator PlayDoorOpeningSequence()
    {
        _doorTransform.transform.rotation = Quaternion.Euler(0, 0, 0);

        while(doorAngle > -90)
        {
            _doorTransform.rotation = Quaternion.Euler(0, doorAngle, 0);
            doorAngle -= Time.deltaTime * _doorOpeningSpeed;
            yield return null;
        }
        
    }

    IEnumerator PlayDoorClosingSequence()
    {
        while (doorAngle < 0)
        {
            _doorTransform.rotation = Quaternion.Euler(0, doorAngle, 0);
            doorAngle += Time.deltaTime * _doorOpeningSpeed;
            yield return null;
        }
    }

}
