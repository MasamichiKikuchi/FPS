using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastTest : MonoBehaviour
{
    public float rayLength = 10f;
    public GameObject masul;
    private LayerMask mask;

    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            masul.GetComponent<ParticleSystem>().Play();
            Ray ray = new Ray(transform.position, transform.forward,mask);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            if (Physics.Raycast(ray, out hit))
            {
                
                
                // Rayがオブジェクトと衝突した場合の処理
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);

                GameObject target = hit.collider.gameObject;
                if (target.tag == "Enemy")
                {
                    target.GetComponent<Enemy>().Damage(1);
                }
                    
                else
                {
                    return;
                }
               
            }
        }
    }
}
