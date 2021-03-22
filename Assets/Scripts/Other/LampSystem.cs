using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSystem : MonoBehaviour
{
    public float intensity;

    private DaySystem globalLight;

    private void Start()
    {
        globalLight = GameObject.Find("Global Light").GetComponent<DaySystem>();
    }

    void Update()
    {
        if (globalLight.currentTime * 24 >= 7 && globalLight.currentTime * 24 <= 18)
            transform.GetComponent<Light>().intensity = 0;
        else
            transform.GetComponent<Light>().intensity = intensity;
    }
}