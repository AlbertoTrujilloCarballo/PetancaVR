using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Player1Text;
    [SerializeField] TextMeshProUGUI Player2Text;

    public int pointsToWin;

    private float currentScore1;
    private float currentScore2;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        
        // Actualiza los textos de puntuación al valor guardado en PlayerPrefs
        UpdatePlayerScores();
    }

    void UpdatePlayerScores()
    {
        // Obtener las puntuaciones del GameManager y actualizar los textos
        int player1Score = (int)gameManager.score1;
        int player2Score = (int)gameManager.score2;

        Player1Text.text = player1Score.ToString();
        Player2Text.text = player2Score.ToString();

        // Verificar si algún jugador ha alcanzado 13 puntos
        if (player1Score >= pointsToWin || player2Score >= pointsToWin)
        {
            Invoke("EndTheGame", 3f);
        }
    }

    void EndTheGame()
    {
        // Reiniciar la escena
        SceneManager.LoadScene("MainMenu");
    }


    public void UpdateScoreRed()
    {
        // Actualiza la puntuación en el GameManager y actualiza el texto
        gameManager.AddScore1();
        UpdatePlayerScores();
    }

    public void UpdateScoreGreen()
    {
        // Actualiza la puntuación en el GameManager y actualiza el texto
        gameManager.AddScore2();
        UpdatePlayerScores();
    }
}
