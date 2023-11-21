using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Play();
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        while (true)
        {          
            yield return new WaitForSeconds(1.0f);
            break;           
        }
        Destroy(gameObject);


    }


}
