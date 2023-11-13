using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectArea : MonoBehaviour
{
    public UnityEvent detect;

    public void OnTriggerStay(Collider other)
    {
        detect.Invoke();
    }
    
}
