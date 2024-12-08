using BT;
using System.Collections.Generic;
using UnityEngine;

public class KnightAI : BTree
{
    public static float speed = 2.0f;
    public static float FOVRange = 4.0f;
    public static float attackRange = 2.0f;

    protected override Node SetupBTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node> {
                new EnemyInFOVRange(transform),
                new GoToTargetAction(transform),
                new EnemyInAttackRange(transform),
                new AttackAction(transform)
            }),
            new PatrolAction(transform),
        });
        return root;
    }

    // Debug for visualization in scene for FOV/Attack range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, FOVRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
