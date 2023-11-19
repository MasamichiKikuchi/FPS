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

    public virtual void enemyAttack(Collider collider)
    {

        Vector3 direction = (collider.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        var test = Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);

        Debug.Log($"レイがあたった{test}");
        
        if (test)
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


