using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGauge : MonoBehaviour
{
    [SerializeField]
    RectTransform parentRectTransform;

    [SerializeField]
    Transform Enemytransform;

   
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(Enemytransform.position);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPoint, null, out Vector2 localPoint);

        transform.localPosition = localPoint + new Vector2(0, 60);
    }
}