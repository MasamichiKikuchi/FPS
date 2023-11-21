using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class RaycastTest : MonoBehaviour
{
    public float rayLength = 10f;
    public GameObject masul;
    [SerializeField]public LayerMask layerMask;
    public AudioClip fire;
    AudioSource audioSource;

    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(fire);
            masul.GetComponent<ParticleSystem>().Play();
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            

            if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                GameObject target = hit.collider.gameObject;
                // Rayがオブジェクトと衝突した場合の処理
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);


                if (target.tag == "Enemy")
                {
                    target.GetComponent<IDamageable>().Damage(1);          }
                else
                {
                    return;          
                }

            }
        }
    }
}
