using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LifeGaugeContainer : MonoBehaviour
{
    /*
    public static LifeGaugeContainer Instance
    {
        get { return Instance; }
    }

    private static LifeGaugeContainer instance;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LifeGauge lifeGaugePrefab;

    private RectTransform rectTransform;
    private readonly Dictionary<Status, Lifegauge> statusLifeBarMap = new Dictionary<MobStatus, LifeGauge>();

    private void Awake()
    {         
      rectTransform = GetComponent<RectTransform>();   
    }

    public void Add(MobStatus status)
    {
        var lifeGauge = Instantiate(lifeGaugePrefab, transform);
        lifeGauge.Initialize(rectTransform, mainCamera, status);
        statusLifeBarMap.Add(status, lifeGauge);   
    }

    public void Remove(MobStatus status)
    {
        Destoroy(statusLifeBarMap[status].gameObject);
        statusLifeBarMap.Remove(status);
    }
    */
}
