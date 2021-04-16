using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private Rigidbody2D rb;
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    private Animator myAnimator;
    public ParticleSystem[] boosters;
    public GameController gameController;
    private bool canDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
    }

    void Update()
    {
        // If the player's speed is 0, then die.
        // if (rb.velocity.magnitude == 0f)
        // {
        //     Destroy(gameObject);
        // }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if (grounded)
            canDoubleJump = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if (grounded)
        {
            boosters[0].Stop();
            boosters[1].Stop();
            jumpTimeCounter = jumpTime;
        }
        else
        {
            boosters[0].Play();
            boosters[1].Play();
        }

        myAnimator.SetFloat("Speed", rb.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    // If the player touches an obstacle then die.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
