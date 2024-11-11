using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float valocityMultiplier = 1.1f;

    private Rigidbody2D ballRb;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }
    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
		float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2 (xVelocity, yVelocity) * initialVelocity;

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= valocityMultiplier;

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.CompareTag("Goal1"))
        {
            // Si toca goal1 ejecutamos funcion de paddle2score
            GameManager.Instance.Paddle2Score();
            // Reiniciamos las paletas y bola a su posicion inicial
            GameManager.Instance.Restart();
            // Lanzamos la bola
            Launch();
        }
        if (collision.gameObject.CompareTag("Goal2"))
        {
            GameManager.Instance.Paddle1Score();
            GameManager.Instance.Restart();
            Launch();
        }
	}

	
}
