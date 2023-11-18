using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobEnemy : Enemy, IDamageable
{
    
    public GameObject player;
    NavMeshAgent agent;

    public GameObject masul;

    public AudioClip fire;
    public AudioClip damageSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        maxLife = 5;
        attakePower = 1;

        life = maxLife;

        agent = GetComponent<NavMeshAgent>();

        LifeGaugeContainer.Instance.Add(this);

        audioSource = GetComponent<AudioSource>();
    }


    public void detect()
    {
        agent.destination = player.transform.position;
    }


    public void enemyAttack(Collider collider)
    {     
        audioSource.PlayOneShot(fire);
        masul.GetComponent<ParticleSystem>().Play();
        base.enemyAttack(collider);
    }

    public void Damage(int damege)
    {     
        audioSource.PlayOneShot(damageSE);
        base.Damage(damege);
    }

}