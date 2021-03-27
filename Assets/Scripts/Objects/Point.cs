using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float distanceToDestroy = 7f;
    RaycastHit hit;
    Ray ray;
    bool checkCollider = false;

    private void Start() 
    {
        StartCoroutine(Wait());
    }

    private void FixedUpdate() 
    {     
        if(!checkCollider)
        {
            ray = new Ray(transform.position, Vector3.back);

            if(Physics.Raycast(ray, out hit, distanceToDestroy))
            {
                if(hit.collider.CompareTag("Car"))
                    Destroy(gameObject);
            }

            ray = new Ray(transform.position, Vector3.forward);

            if(Physics.Raycast(ray, out hit, distanceToDestroy))
            {
                if(hit.collider.CompareTag("Car"))
                    Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") || other.CompareTag("Car"))
        {
            if(other.CompareTag("Player"))
                other.gameObject.GetComponentInParent<Player>().points++;

            Destroy(gameObject);
        }
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(2f);
        checkCollider = true;
    }
}
