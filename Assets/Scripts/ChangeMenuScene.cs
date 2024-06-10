using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenuScene : MonoBehaviour
{
    public void CambiarAlJuego()
    {
        SCManager.instance.LoadScene("MainGame");
    }

        public void CambiarAlMenu()
    {
        SCManager.instance.LoadScene("MainMenu");
    }

    public void CambiarACreditos()
    {
        SCManager.instance.LoadScene("MainCredits");
    }

    public void CerrarJuego(){
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
