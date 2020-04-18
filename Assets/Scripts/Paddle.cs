using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private float mousePosInBlocks;
    private Ball ball;
    // Use this for initialization
    void Start () {
        ball = (Ball)GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }else
        {
            AutoPlay();
        }

	}

    private void AutoPlay()
    {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 8;

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 7.5f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 8;

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 7.5f);

        this.transform.position = paddlePos;
    }
}
