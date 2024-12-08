using BT;
using UnityEngine;
using UnityEngine.AI;

public class GoToTargetAction : Node
{
    private Transform _knight;
    private Animator _animator;
    private NavMeshAgent _agent;
    private float _stoppingDistance = 1.3f;


    public GoToTargetAction(Transform knight)
    {
        _knight = knight;
        _animator = knight.GetComponent<Animator>();
        _agent = knight.GetComponent<NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target == null)
        {
            state = NodeState.FALIURE;
            return state;
        }

        Vector3 directionToTarget = (target.position - _knight.position).normalized;
        Vector3 modifiedTargetPosition = target.position - directionToTarget * _stoppingDistance;

        if (Vector3.Distance(_knight.position, target.position) > _stoppingDistance)
        {
            if (!_agent.hasPath || _agent.destination != modifiedTargetPosition)
            {
                _agent.SetDestination(modifiedTargetPosition);
            }

            _animator.SetBool("Walking", true);
        }
        else
        {
            _agent.ResetPath();
            _animator.SetBool("Walking", false);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
