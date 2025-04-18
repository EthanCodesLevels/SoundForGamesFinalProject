using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public CoinManager cm;

    public float speed;
    private float moveInput;
    public float jumpForce;

    private bool facingRight = true;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
       
        if(facingRight == false && moveInput > 0) 
        {
            Flip();
        } 
        else if (facingRight == true && moveInput < 0) 
        {
            Flip();
        }
    }
    
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround );

        if ( isGrounded == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            isJumping = true;
            jumpTimeCounter = jumpForce;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true) 
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isJumping = false;
        }
    }
    void Flip() 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) 
        {
            Destroy(other.gameObject);
            cm.coinCount++;

        }
    }
    
}

