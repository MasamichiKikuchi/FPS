using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxLife;
    public int life;
    public int attakePower;

    public float rayLength = 10f;
    public LayerMask layerMask;

    public void enemyAttack(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Ray ray = new Ray(transform.position, collider.transform.position);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {

                GameObject target = hit.collider.gameObject;
                if (target.tag == "Player")
                {
                    target.GetComponent<IDamageable>().Damage(attakePower);
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
        Debug.Log($"{this.gameObject.name}のライフ{life}");

        if (life == 0)
        {
            Destroy(gameObject);
            LifeGaugeContainer.Instance.Remove(this);
        }
    }

}


