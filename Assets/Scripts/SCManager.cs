using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour
{

    // Creamos una variable est�tica para almacenar la �nica instancia
    public static SCManager instance;

    private GameManager gameManager;

    // M�todo Awake que se llama al inicio antes de que se active el objeto. �til para inicializar
    // variables u objetos que ser�n llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake()
    {
        // Verificar si ya existe una instancia
        if (instance == null)
        {
            // Si no existe, establecer esta instancia como la �nica instancia
            instance = this;

            // No destruir este objeto cuando se cargue una nueva escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruir este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Obtener referencia al GameManager
        gameManager = GameManager.instance;
    }
    // M�todo para cargar una nueva escena por nombre
    public void LoadScene(string sceneName)
    {
        // Si la escena cargada es el men� principal, restablecer los puntajes
        if (sceneName == "MainMenu")
        {
            AudioManager.instance.PlayMusic($"Menu");
            gameManager.ResetScores();
        }
        if (sceneName == "MainGame")
        {
            AudioManager.instance.PlayMusic($"Game");
        }

        SceneManager.LoadScene(sceneName);
    }

}
