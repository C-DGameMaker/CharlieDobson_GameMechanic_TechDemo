using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;

    [SerializeField] bool _hasTeleported;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hasTeleported = false;
            if (other.transform == _pointA && _hasTeleported == false)
            {
                other.transform.position = _pointB.transform.position;
                _hasTeleported = true;
            }
            else if (other.transform == _pointB && _hasTeleported == false)
            {
                other.transform.position = _pointA.transform.position;
                _hasTeleported = true;
            }
        }
    }

    
}
