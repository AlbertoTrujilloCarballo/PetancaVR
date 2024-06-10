using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    private void Awake()
    {

        // ----------------------------------------------------------------
        // AQUÍ ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del AudioManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------

        // No destruimos el AudioManager aunque se cambie de escena
        DontDestroyOnLoad(gameObject);
    }
}
