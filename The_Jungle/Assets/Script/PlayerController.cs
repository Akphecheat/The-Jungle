using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxspeed;
    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHight;
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}

    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHight));
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("Speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxspeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight)
        {
            flip();
        }
	}

    void flip()
    {
        facingRight =!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
