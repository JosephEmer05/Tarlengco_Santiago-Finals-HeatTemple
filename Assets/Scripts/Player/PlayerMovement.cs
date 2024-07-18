using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.1f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator playerAnim;
    private float horizontalInput;
    public CoinManager coin;
    private bool canJump = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); 

        playerAnim.SetBool("Movement", horizontalInput != 0);
        canJump = isGrounded;

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnim.SetBool("Jumping", true); 
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canJump = false;
            playerAnim.SetBool("Jumping", false); 
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coin.coinCount++;
        }

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
    }
    
    
}
