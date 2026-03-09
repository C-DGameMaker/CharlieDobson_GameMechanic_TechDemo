using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    List<Vector3> _wayPoints = new List<Vector3>();

    private void Start()
    {
        foreach (Transform child in this.transform)
        {
            if (!child.CompareTag("Waypoint")) continue;
            _wayPoints.Add(child.position);
        }
    }
    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        List<Vector3> _gizmoWayPoints = new List<Vector3>();

        foreach(Transform child in this.transform)
        {
            if (!child.CompareTag("Waypoint")) continue;
            _gizmoWayPoints.Add(child.position);
        }

        Gizmos.color = Color.cyan;

        for(int i = 0; i < _gizmoWayPoints.Count; i++)
        {
            Gizmos.DrawSphere(_gizmoWayPoints[i], 0.2f);
            if (i < _gizmoWayPoints.Count - 1)
            {
                Gizmos.DrawLine(_gizmoWayPoints[i], _gizmoWayPoints[i + 1]);
            }
        }
    }
}
