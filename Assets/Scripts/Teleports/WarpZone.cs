using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    [SerializeField] WarpZone _locationOfTeleport;
    [SerializeField] Transform _locationToTeleport;

    [SerializeField] public bool HasTeleported;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Partner"))
        {
            if (HasTeleported == false)
            {
                _locationOfTeleport.HasTeleported = true;
                other.transform.position = _locationOfTeleport.transform.position;
                HasTeleported = false;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Partner"))
        {
            HasTeleported = false;
        }
    }


}
