using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float moveSpeed = 0f;
	private float minMoveSpeed = 0f;
	private float maxMoveSpeed = 0f;
	private float runningRatio = 0.6f;
	private int pos = 0;
	public void MoveSpeedSet(float speed)
	{
		moveSpeed = speed;
		minMoveSpeed = speed * 0.5f;
		maxMoveSpeed = speed * 2.2f;
		
	}
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
        if(GameManager.instance.gameStart==false)
        {
            return;
        }
		ForwardMove();
		SpeedUp();
		SideMove();
	}

	void ForwardMove()
	{
		transform.Translate(Vector3.up*moveSpeed*runningRatio*Time.deltaTime);
	}

	void SpeedUp()
	{
		moveSpeed = moveSpeed * 1.0005f;
        moveSpeed = Mathf.Clamp(moveSpeed,minMoveSpeed, maxMoveSpeed);
	}

	void SideMove()
	{
	#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.A)&&pos>-1)
		{
			pos--;
			transform.Translate(-1.8f,0f,0f);
		}
		if (Input.GetKeyDown(KeyCode.D)&&pos<1)
		{
			pos++;
			transform.Translate(1.8f,0f,0f);
		}
	#endif

	}
	
    public void Right()
    {
        if(pos < 1)
        {
            pos++;
            transform.Translate(1.8f, 0f, 0f);
        }
    }

    public void Left()
    {
        if(pos > -1)
        {
            pos--;
            transform.Translate(-1.8f, 0f, 0f);
        }
    }
}
