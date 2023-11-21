using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy,IDamageable
{
    public GameObject player;
    NavMeshAgent agent;

    public GameObject masul;

    public AudioClip fire;
    public AudioClip damageSE;
    AudioSource audioSource;



    void Start()
    {

        Initialize();

        agent = GetComponent<NavMeshAgent>();

        LifeGaugeContainer.Instance.Add(this);

        audioSource = GetComponent<AudioSource>();
    }

    void Initialize()
    {
        maxLife = 10;
        attakePower = 2;
        score = 200;
        life = maxLife;
    }


    public void detect()
    {
        agent.destination = player.transform.position;
    }


    public override void enemyAttack(Collider collider)
    {
        base.enemyAttack(collider);
        audioSource.PlayOneShot(fire);
        masul.GetComponent<ParticleSystem>().Play();
    }

    public override void Damage(int damege)
    {
        base.Damage(damege);
        audioSource.PlayOneShot(damageSE);    
    }

    
}
