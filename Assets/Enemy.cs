using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    public virtual void Damage(int damege)
    {
        life -= damege;
       
        if (coroutine == false)
        {
            StartCoroutine(ChangeColor());
        }

        if (life == 0)
        {
            Destroy(gameObject);
            LifeGaugeContainer.Instance.Remove(this);
            Score.Instance.AddScore(score);
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

}


