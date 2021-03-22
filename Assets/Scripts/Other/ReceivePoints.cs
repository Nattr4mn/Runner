using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivePoints : MonoBehaviour
{
    RaycastHit hitForward, hitBack;
    Ray ray;

    private void Update() {
        
            // ray = new Ray(transform.position, Vector3.forward);
            // Physics.Raycast(ray, out hitForward, 6f);

            // ray = new Ray(transform.position, Vector3.back);
            // Physics.Raycast(ray, out hitBack, 6f);

            // if((hitForward.collider.tag != null && hitForward.collider.CompareTag("Car")) || (hitForward.collider.tag != null && hitBack.collider.CompareTag("Car")))
            //     Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<Player>().points++;
            Destroy(gameObject);
        }

        if(other.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }
}
