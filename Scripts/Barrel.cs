using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody2D barrelRb;
    private GameManager gameManager;

    // Barrel Speed
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        barrelRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        barrelRb.AddForce(RandomForce(), ForceMode2D.Impulse);
    }

    // Adding force to barrel
    Vector3 RandomForce()
    {
        return Vector2.left * Random.Range(minSpeed, maxSpeed);
    }

    // Score Update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(pointValue);
        }
        Debug.Log("Score Updated");
    }
}
