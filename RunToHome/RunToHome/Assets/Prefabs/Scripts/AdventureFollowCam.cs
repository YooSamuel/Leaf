using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureFollowCam : MonoBehaviour {
    private Transform playerTr;
    private float offsetX = 0;
    private float offsetY = 0;
    void Start()
    {
        playerTr = GameObject.FindWithTag("AdventurePlayer").transform;
        offsetX = transform.position.x - playerTr.position.x;
        offsetY = transform.position.y - playerTr.position.y;
    }

    void LateUpdate()
    {
        Vector3 tempPos = transform.position;
        tempPos.x = playerTr.position.x + offsetX;
        tempPos.y = playerTr.position.y + offsetY;
        transform.position = tempPos;
    }
}
