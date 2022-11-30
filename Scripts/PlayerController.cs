using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;

    public bool isGround;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    // Control Player Movement
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Moving Player
        if (horizontalInput > 0f)
        {
            playerRb.velocity = new Vector2(horizontalInput * playerSpeed, playerRb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0f)
        {
            playerRb.velocity = new Vector2(horizontalInput * playerSpeed, playerRb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        // Jumping Player
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
        }
    }

    // Contoller Player Jump On Ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

  
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
