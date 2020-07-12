using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public SpriteRenderer playerSprite;
    public Animator playerAnimator;

    public bool jumping;
    public bool inTheAir;
    public bool grounded;
    public bool death;

    public float movementSpeed = 5;
    public float movementModifier = 1;
    public float MidAirSpeedModifier = 0.75f;
    public float jumpForce = 1;

    public Rigidbody2D myRigidbody;

    public LayerMask jumpMask;

    public RaycastHit2D hit;

    public PhysicsMaterial2D withFriction;
    public PhysicsMaterial2D withoutFriction;

    public void Start()
    {
        instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();

        InputManager.instance.movingEvent += Move;
        InputManager.instance.notMovingEvent += NotMove;
        InputManager.instance.jumpEvent += Jump;
    }

    public void OnDestroy()
    {
        InputManager.instance.movingEvent -= Move;
        InputManager.instance.notMovingEvent -= NotMove;
        InputManager.instance.jumpEvent -= Jump;
    }

    private void Update()
    {
        playerAnimator.SetFloat("Velocity", myRigidbody.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 2 && grounded == false)
        {
            grounded = true;

            playerAnimator.SetBool("Jumping", false);
            playerAnimator.SetBool("Landed", true);

            if (inTheAir)
                inTheAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;

        playerAnimator.SetBool("Landed", false);
    }

    public void ManageAnimations(float xAxis = 0)
    {
        if(!death)
        {
            if (xAxis < 0)
                playerSprite.flipX = true;
            else if(xAxis > 0)
                playerSprite.flipX = false;

            if (jumping)
            {
                if(!inTheAir)
                {
                    playerAnimator.SetBool("Jumping", true);
                    inTheAir = true;
                }
            }
            else if(grounded)
            {
                if (InputManager.instance.isMoving)
                {
                    if(!playerAnimator.GetBool("Moving"))
                        playerAnimator.SetBool("Moving", true);
                }
                else if(playerAnimator.GetBool("Moving"))
                {
                    playerAnimator.SetBool("Moving", false);
                }
            }
        }
        else
        {
            playerAnimator.SetTrigger("Death");
        }
    }

    public void Move(float xAxis)
    {
        myRigidbody.sharedMaterial = withoutFriction;

        float xMove = xAxis * movementSpeed * 100;
        xMove *= Time.deltaTime;
        xMove *= movementModifier;

        if(!grounded)
        {
            xMove *= MidAirSpeedModifier;
        }

        Vector2 toMove = new Vector2(xMove, myRigidbody.velocity.y);
        myRigidbody.velocity = toMove;

        ManageAnimations(xAxis);
    }

    public void NotMove()
    {
        myRigidbody.sharedMaterial = withFriction;

        ManageAnimations();
    }

    public void Jump()
    {
        if(grounded && !jumping)
        {
            jumping = true;

            myRigidbody.AddForce(new Vector2(0, jumpForce * 100));

            StartCoroutine(NotJumping());

            ManageAnimations();
        }
    }

    public void Death()
    {
        death = true;



        ManageAnimations();
    }

    private IEnumerator NotJumping()
    {
        yield return new WaitForSeconds(0.1f);
        jumping = false;
    }
}
