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
    public AudioClip destrySE;
    AudioSource audioSource;

    bool coroutine = false;

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
      
        if (life == 0)
        {
            audioSource.PlayOneShot(destrySE);
        }

    }
    
}