using BT;
using UnityEngine;

// Add so the knight is running twords enemy if time

public class EnemyInFOVRange : Node
{
    private Animator _animator;
    private Transform _knight;

    private static int _enemyLayer = 1 << 6;

    // Constructor
    public EnemyInFOVRange(Transform knight)
    {
        _knight = knight;
        _animator = knight.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object tar = GetData("target");

        if (tar == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_knight.position, KnightAI.FOVRange, _enemyLayer);

            if (colliders.Length > 0)
            {
                _animator.SetBool("Walking", true);
                parentNode.parentNode.AddData("target", colliders[0].transform);

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FALIURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
