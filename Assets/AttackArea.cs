using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackArea : MonoBehaviour
{

   public Enemy enemy;
   

    public void OnTriggerEnter(Collider other)
    {
        enemy.enemyAttack(other);
    }
}
