using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[] spawnObject;
    private float distanceSpawn;
    private float distanceToDestroy;


    public void Init(GameObject[] spawnObject, float distanceSpawn, float distanceToDestroy)
    {
        this.spawnObject = spawnObject;
        this.distanceSpawn = distanceSpawn;
        this.distanceToDestroy = distanceToDestroy;
    }

    public virtual void Spawn(float offset)
    {
        int[] range = new int[] { -1, 1 };
        int multiplier = range[Random.Range(0, range.Length)];

        Vector3 newPos = new Vector3(transform.position.x + (multiplier * offset), transform.position.y, transform.position.z);
        Instantiate(spawnObject[Random.Range(0, spawnObject.Length)], newPos, Quaternion.identity, transform);
    }

    public virtual void Spawn(GameObject obj, float offset)
    {
        if (Mathf.Abs(obj.transform.position.z - transform.position.z) >= distanceSpawn)
        {
            int[] range = new int[] { -1, 1 };
            int multiplier = range[Random.Range(0, range.Length)];

            Vector3 newPos = new Vector3(transform.position.x + (multiplier * offset), transform.position.y, transform.position.z);
            Instantiate(spawnObject[Random.Range(0, spawnObject.Length)], newPos, Quaternion.identity, transform);
        }
    }

    public virtual void DestroyObject(GameObject obj)
    {
        if (Mathf.Abs(obj.transform.localPosition.z - transform.localPosition.z) >= distanceToDestroy)
        {
            Destroy(obj.gameObject);
        }
    }
}
