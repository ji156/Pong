using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TMP_Text paddle1ScoreText;
	[SerializeField] private TMP_Text paddle2ScoreText;
	[SerializeField] private TMP_Text winnerText;
	[SerializeField] private TMP_Text start;

	[SerializeField] private Transform paddle1Transform;  
	[SerializeField] private Transform paddle2Transform;
	[SerializeField] private Transform ballTransform;

	[SerializeField] private Ball ballVelocity;

	private int paddle1Score;
	private int paddle2Score;
	private string winner1 = "Player 2 Winner";
	private string winner2 = "Player 1 winner";
	private bool endGame;

	private static GameManager instance;

	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}
	}
	void Start()
	{
		// Si no se asigna la referencia en el Inspector, la buscamos en el mismo GameObject
		if (ballVelocity== null)
		{
			ballVelocity= FindObjectOfType<Ball>();
		}
	}

	public void Paddle1Score()
	{
		paddle2Score++;
		paddle2ScoreText.text = paddle2Score.ToString();
		Winner();
		
	}
	public void Paddle2Score()
	{
		paddle1Score++;
		paddle1ScoreText.text = paddle1Score.ToString();
		Winner();
	}

	public void Restart()
	{
		paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
		paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
		ballTransform.position = new Vector2(0, 0);
	}


	public void Winner()
	{
		if (paddle1Score == 5)
		{
			winnerText.text = winner1; // Mostramos el texto del ganador
			EndGame(); // Terminamos el juego
		}
		else if (paddle2Score == 5)
		{
			winnerText.text = winner2; // Mostramos el texto del ganador
			EndGame(); // Terminamos el juego
		}
		else if (ballVelocity.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
		{
			winnerText.text = "";
		}
	}


	public void EndGame()
	{
		paddle1Score = 0;
		paddle2Score = 0;
		paddle1ScoreText.text = paddle1Score.ToString();
		paddle2ScoreText.text = paddle2Score.ToString();
		ballVelocity.initialVelocity = 0;

		// Borra el texto del ganador al finalizar el juego
	}


	public void Delete()
	{
		start.text = "";
	}
}
