using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float rotateSpeed = 200f;  
    public Animator animator;  

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }

        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("shopkeeper"))
            UIManager.Instance.shopButton.SetActive(true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shopkeeper"))
            UIManager.Instance.shopButton.SetActive(false);
    }

}
