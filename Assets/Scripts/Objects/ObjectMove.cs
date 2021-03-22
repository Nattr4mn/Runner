using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed;
    private float maxSpeed;
    private float speedChange;
    private float timeToAcceleration;

    public void Init(float speed, float maxSpeed, float speedChange, float timeToAcceleration)
    {
        this.speed = speed;
        this.maxSpeed = maxSpeed;
        this.speedChange = speedChange;
        this.timeToAcceleration = timeToAcceleration;
        StartCoroutine(Acceleration());
    }

    public void Move(GameObject obj)
    {
        obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator Acceleration()
    {
        while(speed < maxSpeed)
        {
            yield return new WaitForSeconds(timeToAcceleration);
            speed += speedChange;
        }
    }
}
