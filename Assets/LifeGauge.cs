using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    [SerializeField]
    RectTransform _parentRectTransform;

    private Camera _camera;

    private Enemy _status;



   
    void Update()
    {
       Refresh();
    }

    public void Initialize(RectTransform parentRectTransform, Camera camera, Enemy status)
    {
       _parentRectTransform = parentRectTransform;
       _camera = camera;
       _status = status;
        Refresh(); 
    }


    private void Refresh()
    {
        fillImage.fillAmount = _status.life ;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(_status.transform.position);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, screenPoint, null, out Vector2 localPoint);

        transform.localPosition = localPoint + new Vector2(0, 60);
    }
    
}