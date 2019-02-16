using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
	private Transform playerTr;
	private float offsetY = 0;
	void Start ()
	{
		playerTr = GameObject.FindWithTag("Player").transform;
		offsetY = transform.position.y - playerTr.position.y;
		
	}
	
	void LateUpdate ()
	{
		Vector3 tempPos = transform.position;
		tempPos.y = playerTr.position.y + offsetY;
		transform.position = tempPos;
	}
}
