using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform controller;

    public void Init(Transform controller)
    {
        this.controller = controller;
    }

    public void KeyboardController()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(-Input.GetAxis("Horizontal"));
        }
    }

    public void TouchController()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float lastPos = 0, startPos = 0;

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    lastPos = touch.position.x;
                    break;

                case TouchPhase.Ended:
                    if (lastPos - startPos > 0) Move(1f); else Move(-1f);
                    break;
            }
        }
    }

    private void Move(float side)
    {
        controller.position = Vector3.MoveTowards(controller.position, new Vector3(side * 2.5f, controller.position.y, controller.position.z), 50 * Time.deltaTime);
    }
}
