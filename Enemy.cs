using System.Collections;
using UnityEngine;

/*  Code-base made by Mina Pecheux (MIT license) 
    Github: https://github.com/MinaPecheux/UnityTutorials-BehaviourTrees/blob/master/Assets/Scripts/EnemyManager.cs
*/

// Add death aimations and damage taking

public class Enemy : MonoBehaviour
{
    private int _healthpoints;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _healthpoints = 30;
        //Debug.Log("Enemy spawned with " + _healthpoints + " health points.");
    }

    public bool TakeHit()
    {
        _healthpoints -= 10;
        //Debug.Log("Enemy hit! Current health: " + _healthpoints);

        bool isDead = _healthpoints <= 0;
        if (isDead) {
            StartCoroutine(Die());
        }

        return isDead;
    }

    private IEnumerator Die()
    {
        Debug.Log("Enemy died!");

        _animator.SetTrigger("Died");

        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}
