using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Environment
{
    private void Start()
    {
        move = gameObject.AddComponent<ObjectMove>();
        move.Init(speed, maxSpeed, speedChange, timeToAcceleration);

        spawner = gameObject.AddComponent<Spawner>();
        spawner.Init(spawnObject, distanceSpawn, distanceToDestroy);
    }

    void Update()
    {
        Controller();
    }

    public override void Controller()
    {
        int[] range = new int[] { -1, 1 };
        int multiplier = range[Random.Range(0, range.Length)];
        bool canSpawn = Physics.Raycast(new Vector3(transform.position.x + (multiplier * spawnOffset), transform.position.y, transform.position.z),Vector3.forward, distanceSpawn);
        
        if(transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
                move.Move(transform.GetChild(i).gameObject);

            if(canSpawn)
                spawner.Spawn();

            spawner.DestroyObject(transform.GetChild(0).gameObject);
        }
    }
}
