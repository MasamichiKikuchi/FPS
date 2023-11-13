using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackArea : MonoBehaviour
{
    public UnityEvent enemyAttack;

    public void OnTriggerEnter(Collider other)
    {
        enemyAttack.Invoke();
    }
}
