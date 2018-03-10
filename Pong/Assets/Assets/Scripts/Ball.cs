using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;


	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //LeftPaddle or RightPaddle
        if (( col.gameObject.name == "LeftPaddle") ||  
            (col.gameObject.name == "RightPaddle"))
        {
            HandlePaddleHit(col);
        }

        //WallBottom or WallTop
        if ((col.gameObject.name == "WallBottom") ||
            (col.gameObject.name == "WallTop"))
        {
            //play sound
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.WallBloop);
        }

        //LeftGoal or RightGoal
        if ((col.gameObject.name == "LeftGoal") ||
            (col.gameObject.name == "RightGoal"))
        {
            //play sound
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.GoalBloop);

            if(col.gameObject.name == "LeftGoal")
            {
                IncreaseTextUIScore("RightScoreUI");
            }

            if (col.gameObject.name == "RightGoal")
            {
                IncreaseTextUIScore("LeftScoreUI");
            }


            //Reset ball to center of screen
            transform.position = new Vector2(0, 0);
        }
    }


    void HandlePaddleHit(Collision2D col)
    {
        //determines if ball hit paddle straight on, will deflect down, or deflect up
        float y = BallHitPaddleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        //play hit sound
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.HitPaddleBloop);
    }

    
    float BallHitPaddleWhere( Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();
    }
}
