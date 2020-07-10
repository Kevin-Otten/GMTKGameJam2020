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
    public AxisInput MovingEvent;

    public bool isMoving;

    //Asigning empty functions to the delegates to avoid Errors
    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        escapeEvent += Empty;
        MovingEvent += EmptyAxis;
    }

    private void OnDestroy()
    {
        escapeEvent -= Empty;
        MovingEvent -= EmptyAxis;
    }

    private void Update()
    {
        NormalInput();
    }

    //Generic input
    private void NormalInput()
    {
        if (Input.GetButtonDown("Escape"))
            Escape();
    }
    //Fixed update for movementbased input to avoid physics problems
    private void FixedUpdate()
    {
        //Movement input
        if (Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") < 0f)
            Moving(Input.GetAxis("Horizontal"));
        else
            isMoving = false;
    }

    //Generic input
    public void Escape()
    {
        escapeEvent.Invoke();
    }
    //Movement input
    private void Moving(float x)
    {
        isMoving = true;
        MovingEvent.Invoke(x);
    }

    //Empty functions to avoid "nothing inside the delegate" Errors with the delegates
    public void Empty()
    {
    }
    public void EmptyAxis(float xAxis)
    {
    }
}