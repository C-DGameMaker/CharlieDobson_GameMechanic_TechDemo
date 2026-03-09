using System.Collections;
using UnityEngine;

public class DoorOpeningScript : MonoBehaviour
{
    [SerializeField] float _doorOpeningSpeed;
    [SerializeField] float _doorMovingSpeed;

    [SerializeField] Transform _doorTransform;
    [SerializeField] Vector3 _doorOpenPosition;
    [SerializeField] Vector3 _doorClosedPosition;

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
            _doorTransform.localPosition = Vector3.MoveTowards(current: _doorTransform.localPosition, target: _doorOpenPosition, maxDistanceDelta: _doorMovingSpeed * Time.deltaTime);
            doorAngle -= Time.deltaTime * _doorOpeningSpeed;
            yield return null;
        }
        
    }

    IEnumerator PlayDoorClosingSequence()
    {
        while (doorAngle < 0)
        {
            _doorTransform.rotation = Quaternion.Euler(0, doorAngle, 0);
            _doorTransform.localPosition = Vector3.MoveTowards(current: _doorTransform.localPosition, target: _doorClosedPosition  , maxDistanceDelta: _doorMovingSpeed * Time.deltaTime);
            doorAngle += Time.deltaTime * _doorOpeningSpeed;
            yield return null;
        }
    }

}
