using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Declare variables.
    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public float jumpForce;
    private bool canDoubleJump;
    private Rigidbody2D rb;
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    private Animator myAnimator;
    public ParticleSystem[] boosters;
    public GameController gameController;

    // Initialise.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        myAnimator = GetComponent<Animator>();
        speedMilestoneCount = speedIncreaseMilestone;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Speed increase after a certain distance.
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // To jump.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if (grounded)
            canDoubleJump = true;

        // Check if the player can double jump.
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

        // If the player is grounded then the boosters are off or else the boosters are on.
        if (grounded)
        {
            boosters[0].Stop();
            boosters[1].Stop();
        }
        else
        {
            boosters[0].Play();
            boosters[1].Play();
        }

        // For the player animator.
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
