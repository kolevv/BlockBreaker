using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    public float ballSpeed;
    private bool hasStarted = false;

    private AudioSource audio;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) { 
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButton(0))
            {
                hasStarted = true;
                rb.velocity = new Vector2(0f, ballSpeed);

            }
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 rand = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
        if(collision.gameObject.tag != "Breakable")
        {
            audio.Play();
        }
        //rb.velocity += rand;
        rb.velocity += rand;

    }
}
