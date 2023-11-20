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
       Initialize();

        agent = GetComponent<NavMeshAgent>();

        LifeGaugeContainer.Instance.Add(this);

        audioSource = GetComponent<AudioSource>();
    }

    void Initialize()
    {
        maxLife = 5;
        attakePower = 1;
        score = 100;
        life = maxLife;
    }


    public void detect()
    {
        agent.destination = player.transform.position;
    }


    public void enemyAttack()
    {     
        audioSource.PlayOneShot(fire);
        masul.GetComponent<ParticleSystem>().Play();
        base.enemyAttack();
    }

    public override void Damage(int damege)
    {
        base.Damage(damege);
        audioSource.PlayOneShot(damageSE);
       
    }

}