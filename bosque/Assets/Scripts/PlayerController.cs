using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;

    public AudioSource audioSource;
    public AudioClip audioclip;

    [Header("Ground Check Config")]
    public Transform feetCollider; 
    public LayerMask whatIsGround; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y); 


        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (transform.position.y < -12f)
        {
            Die();
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
 
        if (collision.gameObject.CompareTag("Enemies"))
        {

            if (collision.contacts[0].normal.y > 0)
            {

                Destroy(collision.gameObject); 
            }
            else
            {
                
                audioSource.PlayOneShot(audioclip);
                Invoke("Die", 0.6f);
            }
        }

        // Si el jugador toca el final
        if (collision.gameObject.CompareTag("Fin"))
        {
            SceneManager.LoadScene("fin");
        }
    }

    // Función de muerte
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.instance.ReduceVidas();

        if (GameManager.instance.vidas > 1)
        {
            Debug.Log("El jugador tiene " + GameManager.instance.vidas + " vidas");
        }
        else
        {
            Debug.Log("El jugador tiene " + GameManager.instance.vidas + " vida");
        }
    }

    // Comprobación si el jugador está tocando el suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (((1 << collision.gameObject.layer) & whatIsGround) != 0)
    {
        isGrounded = true;  // El jugador está tocando el suelo
    }
    }

    // Cuando el jugador deja de tocar el suelo
    private void OnTriggerExit2D(Collider2D collision)
    {
    if (((1 << collision.gameObject.layer) & whatIsGround) != 0)
    {
        isGrounded = true;  // El jugador está tocando el suelo
    }
    }
}
