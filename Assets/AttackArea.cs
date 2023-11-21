using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackArea : MonoBehaviour
{

    public GameObject enemyObject;
    Enemy enemy;

    private void Start()
    {
        enemy = enemyObject.GetComponent<Enemy>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Loop1(other));
        }
    }

    private IEnumerator Loop1(Collider other)
    {
        while (true)
        {           
            enemy.enemyAttack(other);
          
            yield return new WaitForSeconds(3.0f);
        }
    }
}
