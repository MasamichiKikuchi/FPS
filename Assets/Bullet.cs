using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed;
    public void Fire()
    {
        Debug.Log("����");
        transform.Translate(0, 0, 1);
        
    }


}
