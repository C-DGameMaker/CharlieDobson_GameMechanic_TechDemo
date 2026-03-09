using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    List<Vector3> _wayPoints = new List<Vector3>();
    [SerializeField] float _movementSpeed;

    private Vector3 _currentPos;
    private Vector3 _newPos;

    private bool _isReverse;
    private int _nextPosIndex;

    private float _movementTimer;

    private void Start()
    {
        foreach (Transform child in this.transform)
        {
            if (!child.CompareTag("Waypoint")) continue;
            _wayPoints.Add(child.position);
        }

        _currentPos = _wayPoints[0];
        _newPos = _wayPoints[1];
        _nextPosIndex = 1;
        _isReverse = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

    private void Update()
    {
        _movementTimer += Time.deltaTime / _movementSpeed;
        _movementTimer = Mathf.Min(_movementTimer, 1);
        transform.position = Vector3.Lerp(_currentPos, _newPos, _movementTimer);

        if(Vector3.Distance(transform.position, _newPos) < 0.2)
        {
            _movementTimer = 0;
            if (_nextPosIndex >= _wayPoints.Count - 1)
            {
                _isReverse = true;
            }
            if (_nextPosIndex <= 0)
            {
                _isReverse = false;
            }

            if (_isReverse == false)
            {
                _nextPosIndex++;
                _currentPos = _wayPoints[_nextPosIndex - 1];
                _newPos = _wayPoints[_nextPosIndex];
                
            }
            else if (_isReverse != false)
            {
                
                _nextPosIndex--;
                _currentPos = _wayPoints[_nextPosIndex + 1];
                _newPos = _wayPoints[_nextPosIndex];
                
            }
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
