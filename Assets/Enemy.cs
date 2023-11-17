using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxLife = 5;
    public int life;

    public float rayLength = 10f;
    public GameObject player;
    NavMeshAgent agent;

    public GameObject musul;

    public AudioClip fire;
    public AudioClip damageSE;
    AudioSource audioSource;

    [SerializeField] public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;

        agent = GetComponent<NavMeshAgent>();

        LifeGaugeContainer.Instance.Add(this);

        audioSource = GetComponent<AudioSource>();
    }

    public void Damage(int damege)
    {
        audioSource.PlayOneShot(damageSE);
        life -= damege;
        Debug.Log($"敵のライフ{life}");

        if (life == 0)
        { 
        Destroy(gameObject);
            LifeGaugeContainer.Instance.Remove(this);
        }


    }
    public void detect()
    {
        agent.destination = player.transform.position;       
    }

    public void enemyAttack() 
    {
        audioSource.PlayOneShot(fire);
        musul.GetComponent<ParticleSystem>().Play();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        
        if (Physics.Raycast(ray, out hit,Mathf.Infinity, layerMask))
        {

            GameObject target = hit.collider.gameObject;
            if (target.tag == "Player")
            {
                target.GetComponent<PlayerController>().Damage(1);
            }

            else
            {
                return;
            }
        }
    }
}
