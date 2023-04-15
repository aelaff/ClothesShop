// This script is used to control the character's movement in the game.

using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public Animator animator;  

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the input values for horizontal and vertical axis.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the normalized movement vector.
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        // Apply the movement vector to the Rigidbody2D component.
        rb.velocity = movement * moveSpeed;

        // Flip the character's sprite horizontally when moving to the left.
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
        // Flip the character's sprite horizontally when moving to the right.
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }

        // Set the "isWalking" parameter of the animator based on the movement magnitude.
        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    // This function is called when the character collides with another object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object has a "shopkeeper" tag, activate the shop button in the UI.
        if (collision.gameObject.CompareTag("shopkeeper"))
            UIManager.Instance.shopButton.SetActive(true);
    }
    // This function is called when the character stops colliding with another object.
    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the object has a "shopkeeper" tag, deactivate the shop button in the UI.
        if (collision.gameObject.CompareTag("shopkeeper"))
            UIManager.Instance.shopButton.SetActive(false);
    }

}
