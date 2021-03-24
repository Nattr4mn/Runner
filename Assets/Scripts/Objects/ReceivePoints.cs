using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivePoints : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    private void Update() 
    {     
        ray = new Ray(transform.position, Vector3.back);
        Physics.Raycast(ray, out hit, 6f);

        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Car"))
                Destroy(gameObject);
        }
        else
        {       
            ray = new Ray(transform.position, Vector3.forward);
            Physics.Raycast(ray, out hit, 6f); 

            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Car"))
                    Destroy(gameObject);
            }
        }
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
