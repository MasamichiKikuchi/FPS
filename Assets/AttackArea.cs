using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackArea : MonoBehaviour
{

    public GameObject enemyObject;
    Enemy enemy;
    bool coroutine = false;


    private void Start()
    {
        enemy = enemyObject.GetComponent<Enemy>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coroutine ==false)
            {
                StartCoroutine(EnemyAttackLoop(other));
            }
        }
    }

    private IEnumerator EnemyAttackLoop(Collider other)
    {
        while (true)
        {
            coroutine = true;

            enemy.enemyAttack(other);
          
            yield return new WaitForSeconds(3.0f);

            coroutine = false;

            break;
            
        }
    }
}
