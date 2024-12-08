using BT;
using UnityEngine;

public class AttackAction : Node
{
    private Animator _animator;
    private Transform _lasttraget;
    private Enemy _enemy;
    private float _attackTime = 1.0f;
    private float _attackCount = 0.0f;

    public AttackAction(Transform knight)
    {
        _animator = knight.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target != _lasttraget)
        {
            _enemy = target.GetComponent<Enemy>();
            _lasttraget = target;
        }

        _attackCount += Time.deltaTime;
        if (_attackCount >= _attackTime)
        {
            bool isDead = _enemy.TakeHit();

            if (isDead)
            {
                RemoveData("target");
                _animator.SetBool("Attack", false);
            }
            else
            {
                _attackCount = 0.0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
