using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2;
    public GameObject myPrefab;
    public Animator animator;
    public bool isGround = true;
    private bool isFacingRight = true;
    public Text gemText;
    public int currentGem = 0;



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
        animator.SetBool("Jump", false);
    }

    void Run()
    {
        //horizontal movement
        float movement_x = 0f;
        float movement_y = 0f;
        if (Keyboard.current.leftArrowKey.isPressed) movement_x = -1f;
        if (Keyboard.current.rightArrowKey.isPressed) movement_x = 1f;
        if (Keyboard.current.downArrowKey.isPressed) movement_y = -1f;

        float x_value = movement_x * speed * Time.deltaTime;
        float y_value = movement_y * speed * Time.deltaTime;
        float z_value = 0f;
        transform.position += new Vector3(x_value, y_value, z_value);

        // Flip check
        if (movement_x > 0 && !isFacingRight)
            Flip();
        else if (movement_x < 0 && isFacingRight)
            Flip();

        // Run animation only if on ground
        if (isGround)
        {
            if (Mathf.Abs(movement_x) > 0.1f)
                animator.SetFloat("Run", 1f);
            else
                animator.SetFloat("Run", 0f);
        }
        else
        {
            animator.SetFloat("Run", 0f); // in air, no running animation
        }

    }
    void Jump()
    {
        {
            // Reset jumps if player is on the ground
            if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
            {
                isGround = true;
                jumpsRemaining = maxJumps;
            }
            //Jump input
            if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsRemaining > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                isGround = false;
                animator.SetTrigger("Jump");

                jumpsRemaining--;
            }

        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            // Player touched the ground
            jumpsRemaining = maxJumps;
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        currentGem++;
        Destroy(other.gameObject);
        gemText.text = currentGem.ToString();
    }
}