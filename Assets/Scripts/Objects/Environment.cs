using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float speedChange;
    public float timeToAcceleration;
    public float distanceSpawn;
    public float distanceToDestroy;
    public float spawnOffset;
    public GameObject[] spawnObject;

    protected ObjectMove move;
    protected Spawner spawner;

    private void Start()
    {
        move = gameObject.AddComponent<ObjectMove>();
        spawner = gameObject.AddComponent<Spawner>();

        move.Init(speed, maxSpeed, speedChange, timeToAcceleration);
        spawner.Init(spawnObject, distanceSpawn, distanceToDestroy);
    }

    void Update()
    {
        Controller();
    }

    public virtual void Controller()
    {
        if(transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
                move.Move(transform.GetChild(i).gameObject);

            spawner.Spawn(transform.GetChild(transform.childCount - 1).gameObject, spawnOffset);
            spawner.DestroyObject(transform.GetChild(0).gameObject);
        }
        else
        {
            spawner.Spawn(spawnOffset);
        }
    }
}
