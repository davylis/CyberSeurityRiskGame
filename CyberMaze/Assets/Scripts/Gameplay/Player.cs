using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsRemaining;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }
    

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        
    }
    
    void Run()
    {
        //horizontal movement
        float movement = 0f;
        if (Keyboard.current.leftArrowKey.isPressed) movement = -1f;
        if (Keyboard.current.rightArrowKey.isPressed) movement = 1f;

        transform.position += new Vector3(movement * speed * Time.deltaTime, 0f, 0f);  

        // Flip the sprite based on movement direction
    if (movement != 0)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(movement) * Mathf.Abs(scale.x); // ensure positive/negative X
        transform.localScale = scale;
    } 
    }
    void Jump()
    {
        {
        // Reset jumps if player is on the ground
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            jumpsRemaining = maxJumps;
        }

        // Jump input
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsRemaining > 0)
        {
            // Reset vertical velocity for consistent jump
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // Apply jump force
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            // Decrease jumps remaining
            jumpsRemaining--;
        }
    }
}
}