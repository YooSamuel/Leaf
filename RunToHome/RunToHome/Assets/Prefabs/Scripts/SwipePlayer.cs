using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePlayer : MonoBehaviour {
    Touch touch;
    private PlayerMovement playerMovementScript;
    private GameObject player;
    Vector2 touchPos0;
    Vector2 touchPos1;
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
    }

	void Update ()
    {
        if(Input.touchCount > 0)
        {
            print(Input.touchCount);
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchPos0 = touch.position;
                print("touch begin");
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchPos1 = touch.position;
                print("touch end");

                if (touchPos1.x > touchPos0.x + 20)
                {
                    playerMovementScript.Right();
                   
                    print("left");
                }
                else if (touchPos1.x + 20< touchPos0.x)
                {
                    playerMovementScript.Left();
        
                    print("right");
                }

                touchPos0.x = 0;
                touchPos1.x = 0;
            }
        }
	}
}
