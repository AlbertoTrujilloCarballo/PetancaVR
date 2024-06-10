using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------------------------------------
// SCRIPT PARA LA GESTIÓN DE AUDIO (vinculado a un GameObject vacío "AudioManager")
// ---------------------------------------------------------------------------------
public class AudioManager : MonoBehaviour
{

    // Instancia única del AudioManager (porque es una clase Singleton) STATIC
    public static AudioManager instance;

    // Se crean dos AudioSources diferentes para que se puedan
    // reproducir los efectos y la música de fondo al mismo tiempo
    public AudioSource musicSource; // Componente AudioSource para la música de fondo

    // Añadimos una lista de AudioSources para efectos de sonido
    public List<AudioSource> sfxSources = new List<AudioSource>();

    // En vez de usar un vector de AudioClips (que podría ser) vamos a utilizar un Diccionario
    // en el que cargaremos directamente los recursos desde la jerarquía del proyecto
    // Cada entrada del diccionario tiene una string como clave y un AudioClip como valor
    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    // Método Awake que se llama al inicio antes de que se active el objeto. Útil para inicializar
    // variables u objetos que serán llamados por otros scripts (game managers, clases singleton, etc).
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

        // Cargamos los AudioClips en los diccionarios
        LoadSFXClips();
        LoadMusicClips();
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic($"Menu");
    }

    // Método privado para cargar los efectos de sonido directamente desde las carpetas
    private void LoadSFXClips()
    {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCIÓN DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/SFX
        sfxClips["getGem"] = Resources.Load<AudioClip>("SFX/getGem");
        sfxClips["Sand"] = Resources.Load<AudioClip>("SFX/Sand");
        sfxClips["Attraction"] = Resources.Load<AudioClip>("SFX/Attraction");
        sfxClips["Repulsion"] = Resources.Load<AudioClip>("SFX/Repulsion");
        sfxClips["Cry"] = Resources.Load<AudioClip>("SFX/Cry");
    }

    // Método privado para cargar la música de fondo directamente desde las carpetas
    private void LoadMusicClips()
    {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCIÓN DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/Music
        musicClips["Menu"] = Resources.Load<AudioClip>("Music/Menu");
        musicClips["Game"] = Resources.Load<AudioClip>("Music/Game");
    }

    // Método de la clase singleton para reproducir efectos de sonido
    public void PlaySFX(string clipName)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            // Encuentra un AudioSource disponible para reproducir el efecto de sonido
            AudioSource availableSource = sfxSources.Find(source => !source.isPlaying);
            if (availableSource != null)
            {
                availableSource.clip = sfxClips[clipName];
                availableSource.Play();
            }
            else
            {
                Debug.LogWarning("No hay AudioSource disponible para reproducir el efecto de sonido.");
            }
        }
        else
        {
            Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de sfxClips.");
        }
    }

    // Método de la clase singleton para reproducir música de fondo
    public void PlayMusic(string clipName)
    {
        if (musicClips.ContainsKey(clipName))
        {
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
            musicSource.loop = true;
        }
        else
        {
            Debug.LogWarning("El AudioClip " + clipName + " no se encontró en el diccionario de musicClips.");
        }
    }

    public void SetVolume(float value)
    {
        foreach (var source in sfxSources)
        {
            source.volume = value;
        }
        musicSource.volume = value;
    }
}
