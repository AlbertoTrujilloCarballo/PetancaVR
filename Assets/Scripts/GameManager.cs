using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Creamos una variable est�tica para almacenar la �nica instancia
    public static GameManager instance;

    // M�todo Awake que se llama al inicio antes de que se active el objeto. �til para inicializar
    // variables u objetos que ser�n llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        // No destruimos el SceneManager aunque se cambie de escena
        DontDestroyOnLoad(gameObject);

    }


    public float score1 = 0;
    public float score2 = 0;

    public void AddScore1()
    {
        score1++;
    }

    public void AddScore2() { score2++; }

    public void ResetScores()
    {
        score1 = 0;
        score2 = 0;
    }



}
