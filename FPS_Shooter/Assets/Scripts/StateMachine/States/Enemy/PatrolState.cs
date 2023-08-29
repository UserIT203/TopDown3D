using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private Path _path;
    [SerializeField] private float _waitingTime;

    private float _currentTime;
    private List<Transform> _waypoints;
    private int _currentWaypointNumber = 0;

    private void Start()
    {
        _waypoints = _path.Waypoints;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _waitingTime)
        {
            Vector3 target = GetWaypointPosition(_currentWaypointNumber);
            Agent.SetDestination(target);

            _currentTime = 0;
        }
    }

    private void OnDestroy()
    {
        Destroy(_path.gameObject);
    }

    private Vector3 GetWaypointPosition(int waypointNumber)
    {
        if (waypointNumber >= _waypoints.Count - 1)
            _currentWaypointNumber = 0;
        else
            _currentWaypointNumber++;

        return _waypoints[_currentWaypointNumber].position;
    }
}
