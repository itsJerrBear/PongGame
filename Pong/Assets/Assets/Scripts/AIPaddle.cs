using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {

    public Ball theBall;

    public float speed = 30;

    //smooth out movement over time
    public float lerpAdjust = 2f;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();

	}

    private void FixedUpdate()
    {
        if(theBall.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0,1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpAdjust * Time.deltaTime);
        }

        else if (theBall.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpAdjust * Time.deltaTime);
        }

        else
        {
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpAdjust * Time.deltaTime);
        }

    }
}
