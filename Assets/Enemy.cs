using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    public int maxLife;
    public int life;
    public int attakePower;
    public int score;

    public float rayLength = 10f;
    public LayerMask layerMask;

    bool coroutine = false;

    public virtual void enemyAttack(Collider collider)
    {

        Vector3 direction = (collider.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);

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

    public virtual void Damage(int damege)
    {
        life -= damege;
        
        if (coroutine == false)
        {
            StartCoroutine(ChangeColor());
        }

        if (life == 0)
        {
           
            LifeGaugeContainer.Instance.Remove(this);
            Score.Instance.AddScore(score);
            Destroy(gameObject);

        }
    }
    IEnumerator ChangeColor()
    {
        var color = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.5f);

        while (true)
        {
            coroutine = true;
            yield return new WaitForSeconds(0.2f);
            coroutine = false;
            break;

        }

        GetComponent<Renderer>().material.color = color;
    }
    public GameObject particleSystemPrefab;

    private void OnDestroy()
    {
        if (particleSystemPrefab != null)
        {
            Instantiate(particleSystemPrefab, transform.position, transform.rotation);
        }
    }



}


