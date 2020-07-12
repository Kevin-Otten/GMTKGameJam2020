using UnityEngine;

//This Manager is used as a centralized point for all of the Players Input.
//This makes it easier to find problems related to input for debugging purposes.

public class InputManager : MonoBehaviour
{
    //public static InputManager instance;
    public static InputManager instance;

    //Input Delegates. subscribe a function to trigger its contents on input.
    public delegate void BaseInput();
    public delegate void AxisInput(float xAxis);

    public BaseInput escapeEvent;
    public BaseInput jumpEvent;
    public BaseInput holdingJumpEvent;
    public BaseInput notHoldingJumpEvent;
    public BaseInput notMovingEvent;
    public AxisInput movingEvent;

    public bool isMoving;

    //Asigning empty functions to the delegates to avoid Errors
    private void Awake()
    {
        instance = this;

        escapeEvent += Empty;
        jumpEvent += Empty;
        holdingJumpEvent += Empty;
        notHoldingJumpEvent += Empty;
        notMovingEvent += Empty;
        movingEvent += EmptyAxis;
    }

    private void OnDestroy()
    {
        escapeEvent -= Empty;
        jumpEvent -= Empty;
        holdingJumpEvent -= Empty;
        notHoldingJumpEvent -= Empty;
        notMovingEvent -= Empty;
        movingEvent -= EmptyAxis;
    }

    //Update for general input
    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
            Escape();
        if (Input.GetButtonDown("Jump"))
            Jump();
        if (Input.GetButton("Jump"))
            HoldingJump();
        if (Input.GetButtonUp("Jump"))
            NotHoldingJump();

    }

    //Fixed update for movementbased input to avoid physics problems
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") < 0f)
        {
            Moving(Input.GetAxis("Horizontal"));
        }
        else
        {
            NotMoving();
        }
    }

    //Generic input
    public void Escape()
    {
        escapeEvent.Invoke();
    }
    public void Jump()
    {
        jumpEvent.Invoke();
    }
    public void HoldingJump()
    {
        holdingJumpEvent.Invoke();
    }
    public void NotHoldingJump()
    {
        notHoldingJumpEvent.Invoke();
    }
    //Movement input
    private void Moving(float x)
    {
        isMoving = true;
        movingEvent.Invoke(x);
    }
    private void NotMoving()
    {
        isMoving = false;
        notMovingEvent.Invoke();
    }

    //Empty functions to avoid "nothing inside the delegate" Errors with the delegates
    public void Empty()
    {
    }
    public void EmptyAxis(float xAxis)
    {
    }
}