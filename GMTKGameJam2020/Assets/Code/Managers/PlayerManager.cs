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
    public PhysicsMaterial2D withLimitedFriction;
    public PhysicsMaterial2D withoutFriction;

    //JumpControll values
    private float jumpTimeCounter;
    public float jumpTime;
    private bool holdingSpace;

    public bool inverseControls;
    public bool inactiveControls;

    public void Awake()
    {
        instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        InputManager.instance.movingEvent += Move;
        InputManager.instance.notMovingEvent += NotMove;
        InputManager.instance.jumpEvent += Jump;
        InputManager.instance.holdingJumpEvent += HoldingJump;
        InputManager.instance.notHoldingJumpEvent += NotHoldingJump;
    }

    public void OnDestroy()
    {
        InputManager.instance.movingEvent -= Move;
        InputManager.instance.notMovingEvent -= NotMove;
        InputManager.instance.jumpEvent -= Jump;
        InputManager.instance.holdingJumpEvent -= HoldingJump;
        InputManager.instance.notHoldingJumpEvent -= NotHoldingJump;
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
        if(!inactiveControls)
        {
            if(!death)
            {
                if (xAxis < 0 && !inverseControls || xAxis > 0 && inverseControls)
                    playerSprite.flipX = true;
                else if(xAxis > 0 && !inverseControls || xAxis< 0 && inverseControls)
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
    }

    public void Move(float xAxis)
    {
        if(!inactiveControls)
        {
            myRigidbody.sharedMaterial = withoutFriction;

            float xMove = xAxis * movementSpeed * 100;
            xMove *= Time.deltaTime;
            xMove *= movementModifier;

            if(!grounded)
            {
                xMove *= MidAirSpeedModifier;
            }

            Vector2 toMove = new Vector2(0, 0);

            if(!inverseControls)
            {
                toMove = new Vector2(xMove, myRigidbody.velocity.y);
            }
            else
            {
                toMove = new Vector2(-xMove, myRigidbody.velocity.y);
            }

            myRigidbody.velocity = toMove;

            ManageAnimations(xAxis);
        }
    }

    public void NotMove()
    {
        if(!inactiveControls)
        {
            myRigidbody.sharedMaterial = withFriction;

            ManageAnimations();
        }
    }

    public void Jump()
    {
        if(!inactiveControls)
        {
            if(grounded && !jumping)
            {
                jumping = true;
                holdingSpace = true;
                jumpTimeCounter = jumpTime;

                myRigidbody.velocity = Vector2.up * jumpForce;

                StartCoroutine(NotJumping());

                ManageAnimations();
            }
        }
    }

    public void HoldingJump()
    {
        if (!inactiveControls)
        {
            if (holdingSpace)
            {
                if(jumpTimeCounter > 0)
                {
                    myRigidbody.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    holdingSpace = false;
                }
            }
        }
    }

    public void NotHoldingJump()
    {
        holdingSpace = false;
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
