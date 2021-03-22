using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    public int distance = 0;
    public Text distanceText;

    public float speed;
    public float minSpeed;

    private void Start()
    {
        distanceText.text = distance.ToString();
        StartCoroutine(SpeedChange());
        StartCoroutine(Distance());
    }

    private IEnumerator SpeedChange()
    {
        yield return new WaitForSeconds(5f);
        speed -= 0.02f;
        if(speed >= minSpeed)
            StartCoroutine(SpeedChange());
    }

    private IEnumerator Distance()
    {
        yield return new WaitForSeconds(speed);
        distance++;
        distanceText.text = distance.ToString();
        StartCoroutine(Distance());
    }
}
