using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LifeGaugeContainer : MonoBehaviour
{
    
    public static LifeGaugeContainer Instance
    {
        get { return instance; }
    }

    private static LifeGaugeContainer instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LifeGauge lifeGaugePrefab;

    private RectTransform rectTransform;
    private readonly Dictionary<Enemy, LifeGauge> statusLifeBarMap = new Dictionary<Enemy, LifeGauge>();

    private void Awake()
    {        
      instance = this;
      rectTransform = GetComponent<RectTransform>();   
    }

    public void Add(Enemy status)
    {
        var lifeGauge = Instantiate(lifeGaugePrefab, transform);
        lifeGauge.Initialize(rectTransform, mainCamera, status);
        statusLifeBarMap.Add(status, lifeGauge);   
    }

    public void Remove(Enemy status)
    {
        Destroy(statusLifeBarMap[status].gameObject);
        statusLifeBarMap.Remove(status);
    }
    
}
