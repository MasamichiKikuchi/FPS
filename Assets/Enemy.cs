using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    int maxLife = 5;
    int life;

    public float rayLength = 10f;
    public GameObject player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    
     void Update()
     {

        agent.destination = player.transform.position;
       
        
        if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
                if (Physics.Raycast(ray, out hit))
                {


                    // Rayがオブジェクトと衝突した場合の処理
                    Debug.Log("Hit an object: " + hit.collider.gameObject.name);

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
   

    public void Damage(int damege)
    { 
      life -= damege;
        Debug.Log($"敵のライフ{life}");

        if (life == 0)
        { 
        Destroy(gameObject);       
        }
    }
}
