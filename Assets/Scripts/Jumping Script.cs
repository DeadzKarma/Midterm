using UnityEngine;
using UnityEngine.InputSystem;

public class jump : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10f;
    public Rigidbody2D myRB;
    public float jumpForce = 100f;
    public bool isGrounded;
    public float jumpTimer = 0f;
    public float jumpReset = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            direction += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            direction += Vector3.right;
        }

        direction = direction * speed;
        direction.y = myRB.linearVelocity.y;
        myRB.linearVelocity = direction;

        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            myRB.AddForce(Vector3.up * jumpForce);
        }

    }

    void Update()
    {
        //check to see if jump is on cooldown
        if (jumpTimer > 2f)
        {
            jumpReset -= Time.deltaTime;
        }

        //if jump reset is up, cycel the timers back
        if (jumpReset <= 0f)
        {
            jumpTimer = 0f;
            jumpReset = 2f;
        }
    }

}
