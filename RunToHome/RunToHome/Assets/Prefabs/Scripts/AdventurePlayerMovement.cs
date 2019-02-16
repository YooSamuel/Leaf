using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurePlayerMovement : MonoBehaviour {
    public int posX = 0;
    public int posY = 0;
    public float movement = 50f;
    public float second = 0.1f;
    private bool isMoving = false;
    Coroutine coroutineA;
    private Animator PomeranianAnimator;


	void Start () {
        PomeranianAnimator = GameObject.FindWithTag("AdventurePlayer").GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {

        print("1");
        
        yield return new WaitForSeconds(0.2f);
    }

    void Update () {
        Move();
	}

    void Move()
    {
#if UNITY_EDITOR

        if (isMoving == false)
        {
            PomeranianAnimator.SetInteger("Running", 0);
        }

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            coroutineA = StartCoroutine(left());
        }
        else if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            coroutineA = StartCoroutine(right());
        }
        else if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            coroutineA = StartCoroutine(down());
        }
        else if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            coroutineA = StartCoroutine(up());
        }

        
        else
        {
            
        }
      
#endif
    }

    IEnumerator left()
    {
        isMoving = true;
        PomeranianAnimator.SetInteger("Running", 1);

        posX--;
        transform.up = Vector3.left;
        transform.Translate(0f, movement, 0f);

        yield return new WaitForSeconds(second);

        isMoving = false;
    }
    IEnumerator right()
    {
        isMoving = true;
        PomeranianAnimator.SetInteger("Running", 1);

        posX++;
        transform.up = Vector3.right;
        transform.Translate(0f, movement, 0f);

        yield return new WaitForSeconds(second);

        isMoving = false;
    }
    IEnumerator up()
    {
        isMoving = true;
        PomeranianAnimator.SetInteger("Running", 1);

        posY++;
        transform.up = Vector3.up;
        transform.Translate(0f, movement, 0f);

        yield return new WaitForSeconds(second);

        isMoving = false;
    }
    IEnumerator down()
    {
        isMoving = true;
        PomeranianAnimator.SetInteger("Running", 1);

        posY--;
        transform.up = Vector3.down;
        transform.Translate(0f, movement, 0f);

        yield return new WaitForSeconds(second);

        isMoving = false;
    }
}
