using BT;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAction : Node
{
    private Transform _knight;
    private Animator _animator;
    private NavMeshAgent _agent;
    private Transform _currentWaypoint;

    private float _waitCont = 0.0f;
    private float _randWaitTime = 1.0f;
    private float _waypointThreshold = 0.1f;

    private bool _waiting = false;
    private bool _firstRun = true;

    public PatrolAction(Transform knight)
    {
        _knight = knight;
        _animator = knight.GetComponent<Animator>();
        _agent = knight.GetComponent<NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCont += Time.deltaTime;
            if (_waitCont >= _randWaitTime)
            {
                _waiting = false;
                _agent.isStopped = false;
                _currentWaypoint = NextRandWaypoint();
                _agent.SetDestination(_currentWaypoint.position);
            }
            _animator.SetBool("Walking", false);
        }
        else
        {
            if (_currentWaypoint == null || _firstRun)
            {
                _currentWaypoint = NextRandWaypoint();
                _agent.SetDestination(_currentWaypoint.position);
                _firstRun = false;
            }

            if (!_agent.pathPending && _agent.remainingDistance <= _waypointThreshold)
            {
                if (_agent.velocity.sqrMagnitude <= 0.1f)
                {
                    _waitCont = 0.0f;
                    _waiting = true;
                    _randWaitTime = Random.Range(0.5f, 2.5f);
                    _agent.isStopped = true;
                    _agent.ResetPath();

                    GameObject.Destroy(_currentWaypoint.gameObject);
                }
            }
            else
            {
                _animator.SetBool("Walking", true);
            }
        }

        // Debug waypoint line in scene view
        if (_currentWaypoint != null)
        {
            Debug.DrawLine(_knight.position, _currentWaypoint.position, Color.yellow);
        }

        state = NodeState.RUNNING;
        return state;
    }

    private Transform NextRandWaypoint()
    {
        Vector3 randomDirection = _knight.position + Random.insideUnitSphere * 20f;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 20f, NavMesh.AllAreas))
        {
            GameObject waypoint = new("Waypoint");
            waypoint.transform.position = hit.position;
            return waypoint.transform;
        }
        else
        {
            return null;
        }
    }
}
