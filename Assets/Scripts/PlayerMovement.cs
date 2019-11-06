using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float playerAccel; 
	public float jumpStrength;
	public bool grounded;
    // Start is called before the first frame update

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float groundDetectDist = 0.5f; //DONT TOUCH THIS UNLESS AARON SAYS YOU CAN
    public bool detectBigWorld = false;
    public bool detectSmallWorld = false;

    void Start() {
        playerAccel = 7.5f; //the initial acceleration
        jumpStrength = 10f;   
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    } //end of Start

    // Update is called once per frame
    void Update() {
        IsOnGround(); //check if we are grounded or not
    	Jump();
    	Movement();

    } //end of update

     void Jump(){
     	if(Input.GetButtonDown("Jump") && grounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
            animator.SetBool("Land", false);
            animator.SetBool("Jump_Up", true);
     	} //end of if
     } //end of jump

     void Movement(){
         float move = Input.GetAxis("Horizontal");
         rb2d.velocity = new Vector2(move * playerAccel, rb2d.velocity.y);
         Vector2 movement = new Vector2(move, 0f);
        if (move < 0)
            spriteRenderer.flipX = true;
        else if (move> 0)
            spriteRenderer.flipX = false;
         animator.SetFloat("Speed", Mathf.Abs(move*playerAccel));

         rb2d.AddForce(movement * playerAccel);
     } //end of movement

    private void IsOnGround()
    { //returns true if the character is on the ground
        LayerMask groundMask = 1 << 8;
        LayerMask smallMask = 1 << 9;
        LayerMask bigMask = 1 << 10;

        if (Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), groundDetectDist, groundMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(detectSmallWorld)
            {
                if (Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), groundDetectDist, smallMask))
                {
                    grounded = true;
                } 
            }
        if(detectBigWorld)
            {
                if (Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), groundDetectDist, bigMask))
                {
                    grounded = true;
                }
            }
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Ground") {
            grounded = true;
            animator.SetBool("Land", true);
            animator.SetBool("Jump_Up", false);
        }
        
    } //end of method onced2d

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.collider.tag == "Ground"){
            grounded = true;
            if(animator.GetBool("Land") == true)
                animator.SetBool("Land", false);
        }
    }//end of method onced2d

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -new Vector3(0.0f, groundDetectDist, 0.0f));
    }
}
