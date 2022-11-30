using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private float verticalInput;
    private float speed = 8.0f;
    private bool isLadder;
    private bool isClimbing;

    public Rigidbody2D ladderRb;

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        if(isLadder && verticalInput > 0f)
        {
            isClimbing = true;
        }
    }

    // Add physics on Ladder movement
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            ladderRb.gravityScale = 0f;
            ladderRb.velocity = new Vector2(ladderRb.velocity.x, verticalInput * speed);
        }
        else
        {
            ladderRb.gravityScale = 4f;
        }
    }

    // Laddder Detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    // Ladder Exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
