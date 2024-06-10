using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour
{

    // Creamos una variable estática para almacenar la única instancia
    public static SCManager instance;

    private GameManager gameManager;

    // Método Awake que se llama al inicio antes de que se active el objeto. Útil para inicializar
    // variables u objetos que serán llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake()
    {
        // Verificar si ya existe una instancia
        if (instance == null)
        {
            // Si no existe, establecer esta instancia como la única instancia
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
    // Método para cargar una nueva escena por nombre
    public void LoadScene(string sceneName)
    {
        // Si la escena cargada es el menú principal, restablecer los puntajes
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
