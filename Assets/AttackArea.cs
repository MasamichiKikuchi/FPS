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
          enemy.enemyAttack(other);
        }
    }
}
