using UnityEngine;
using BT;

public class EnemyInAttackRange : Node
{
    private Animator _animator;
    private Transform _knight;

    public EnemyInAttackRange(Transform knight)
    {
        _knight = knight;
        _animator = knight.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        {
            object tar = GetData("target");

            if (tar == null)
            {
                state = NodeState.FALIURE;
                return state;
            }

            Transform target = (Transform)tar;

            if (Vector3.Distance(_knight.position, target.position) <= KnightAI.attackRange)
            {
                _animator.SetBool("Attack", true);
                _animator.SetBool("Walking", false);

                Debug.Log("Distance to target: " + Vector3.Distance(_knight.position, target.position));
                Debug.Log("Attack range: " + KnightAI.attackRange);

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FALIURE;
            return state;
        }
    }
}
