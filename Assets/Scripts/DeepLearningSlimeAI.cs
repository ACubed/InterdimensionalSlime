using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { walking, waiting, jumping}
public class DeepLearningSlimeAI : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float playerAccel;
    public float jumpStrength;

    public State currentState = State.waiting;

    public float maxWalkTime = 2f;

    public float maxWaitTime = 3f;
    public float waitTimeBetweenJumps = 1f;
    public int maxJumps = 3;

    public bool grounded;

    private int jumpsLeft = 0;
    private float actionTimeLeft = 0f;

    private bool walkingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentState = State.waiting;
        actionTimeLeft = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.waiting)
        {
            actionTimeLeft -= Time.deltaTime;
            if (actionTimeLeft <= 0) {
                ChooseNewAction();
            }
        }
        else if (currentState == State.walking)
        {
            actionTimeLeft -= Time.deltaTime;
            if (actionTimeLeft <= 0)
            {
                ChooseNewAction();
            }
            else {
                float move;
                if (walkingLeft)
                {
                    move = -1;
                }
                else {
                    move = 1;
                }
                rb2d.velocity = new Vector2(move * playerAccel, rb2d.velocity.y);
                Vector2 movement = new Vector2(move, 0f);
                rb2d.AddForce(movement * playerAccel);
            }
        }
        else if (currentState == State.jumping) 
        {
            if (grounded) {
                actionTimeLeft -= Time.deltaTime;
                if (actionTimeLeft <= 0) {
                    if (jumpsLeft > 0)
                    {
                        jumpsLeft--;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
                        actionTimeLeft = waitTimeBetweenJumps;
                    }
                    else {
                        ChooseNewAction();
                    }
                }
            }
        }
    }

    void ChooseNewAction() {
        int actionIndex = (int)Mathf.Floor(Random.Range(0, 3));
        if (actionIndex == 0)
        {
            currentState = State.jumping;
            actionTimeLeft = Mathf.Floor(Random.Range(0, maxWaitTime)) + 1f;
        }
        else if (actionIndex == 1)
        {
            currentState = State.jumping;
            jumpsLeft = (int)Mathf.Floor(Random.Range(0, maxJumps)) + 1;
        }
        else if (actionIndex == 2)
        {
            currentState = State.walking;
            if (transform.position.x <= 0)
            {
                walkingLeft = false;
            }
            else 
            {
                walkingLeft = true;
            }

            actionTimeLeft = Mathf.Floor(Random.Range(0, maxWalkTime)) + 1f;
        }
        else if (actionIndex == 3)
        {
            currentState = State.jumping;
            jumpsLeft = maxJumps + 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            grounded = true;
    } //end of method onced2d

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            grounded = false;
    }//end of method onced2d
}
