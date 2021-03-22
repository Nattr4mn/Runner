using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public int points = 0;

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
        move.Move(target);
    }
}
