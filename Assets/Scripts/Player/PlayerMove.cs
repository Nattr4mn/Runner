using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    GameObject player;
    public void Init(GameObject player)
    {
        this.player = player;
    }
    public void Move(Transform target)
    {
        Vector3 newPos = new Vector3(target.position.x, player.transform.position.y, player.transform.position.z);
        player.transform.LookAt(target);
        player.transform.position = Vector3.MoveTowards(player.transform.position, newPos, 10 * Time.deltaTime);
    }
}
