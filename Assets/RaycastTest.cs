using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float rayLength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            if (Physics.Raycast(ray, out hit))
            {
                // Rayがオブジェクトと衝突した場合の処理
                Debug.Log("Hit an object: " + hit.collider.gameObject.name);
            }
        }
    }
}
