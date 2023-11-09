using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxLife = 5;
    int life;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damege)
    { 
      life -= damege;
        Debug.Log($"“G‚Ìƒ‰ƒCƒt{life}");

        if (life == 0)
        { 
        Destroy(gameObject);       
        }
    }
}
