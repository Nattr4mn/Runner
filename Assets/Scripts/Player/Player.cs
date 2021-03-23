using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public int points = 0;
    public bool life { get; private set;} = true;

    PlayerController controller;
    PlayerMove move;


    void Start()
    {
        controller = gameObject.AddComponent<PlayerController>();
        controller.Init(target);
        move = gameObject.AddComponent<PlayerMove>();
        move.Init(player);
    }

    // Update is called once per frame
    void Update()
    {
        controller.KeyboardController();
        controller.TouchController();
        controller.SwipeController();
        move.Move(target);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Car"))
        {
            Handheld.Vibrate();
            life = false;
            Time.timeScale = 0f;
        }
    }
}
