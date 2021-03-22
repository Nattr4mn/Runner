using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform controller;
    bool directionChosen = false;
    Vector2 startPos = new Vector2();
    Vector2 direction = new Vector2();

    public void Init(Transform controller)
    {
        this.controller = controller;
    }

    public void KeyboardController()
    {
        if (Input.GetAxis("Horizontal") > 0.1f)
            Move(-1);
        else if (Input.GetAxis("Horizontal") < -0.1f)
            Move(1);

    }

    public void TouchController()
    {

        if (Input.touchCount > 0) 
        { 
            Touch touch = Input.GetTouch(0);

            switch (touch.phase) 
            {
                case TouchPhase.Began : 
                    startPos = touch.position; 
                    directionChosen = false; 
                    break; 

                case TouchPhase.Moved : 
                    direction = touch.position - startPos; 
                    break; 

                case TouchPhase.Ended : 
                    directionChosen = true;
                    break; 
            } 
        } 

        if (directionChosen) 
        { 
            if(direction.x - startPos.x > 0)
                Move(-1);
            if(direction.x - startPos.x < 0)
                Move(1);
        } 
    }

    private void Move(float side)
    {
        print(side);
        controller.position = Vector3.MoveTowards(controller.position, new Vector3(side * 2.5f, controller.position.y, controller.position.z), 50 * Time.deltaTime);
    }
}
