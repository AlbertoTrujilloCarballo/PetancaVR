//#define OLD_SETTINGS
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;





public class SettingsController : MonoBehaviour
{
    // Referencia al mute

    // Referencia al volumen
    private float musicVolumeMusic;
    private float musicVolumeSFX;
    // Referencia al AudioSource con la música
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource sfxSource2;

    int savedMute;
    float savedVolumeMusic;
    float savedVolumeSFX;


#if OLD_SETTINGS
    //[SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TMP_Text volumeText;
    public int changeVolume;
#else
    [SerializeField] UnityEngine.UI.Slider sliderMusic;
    [SerializeField] UnityEngine.UI.Slider sliderSFX;
    //[SerializeField] UnityEngine.UI.Toggle toggle;
#endif
    // Start is called before the first frame update
    void Start()
    {
        //sliderMusic = GameObject.Find("SliderMusic").GetComponent<Slider>();
        //sliderSFX = GameObject.Find("SliderSFX").GetComponent<Slider>();
        //toggle = GameObject.Find("Toggle").GetComponent<UnityEngine.UIElements.Toggle>();
        //volumeText.text = $"Volume:{audioSource.volume * 100}";
        //audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        // Recupera la configuración del volumen (si existe) o utiliza un valor predeterminado
        savedVolumeMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        savedVolumeSFX = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        // Recupera la configuración del mute
        savedMute = PlayerPrefs.GetInt("MuteAll");
        LoadVolumeMusic(savedVolumeMusic); // Configuramos el volumen cargado
        LoadVolumeSFX(savedVolumeSFX); // Configuramos el volumen cargado
        //LoadMute(savedMute); // Configuramos el estado del muteo cargado
    }

    void LoadVolumeMusic(float volume)
    { // Método para configurar un volumen específico en el Slider
        musicVolumeMusic = volume; // Configuramos el volumen como corresponda
        musicSource.volume = volume; // Configuramos el AudioSource como corresponda
        sliderMusic.value = volume;
    }
    void LoadVolumeSFX(float volume)
    { // Método para configurar un volumen específico en el Slider
        musicVolumeSFX = volume; // Configuramos el volumen como corresponda
        sfxSource.volume = volume; // Configuramos el AudioSource como corresponda
        sfxSource2.volume = volume;
        sliderSFX.value = volume;
    }

    //void LoadMute(int mute)
    //{ // Método para configurar el estado del Mute
    //    Debug.Log("playerprefs1 "+PlayerPrefs.GetInt("MuteAll"));
    //    musicSource.mute = !(mute == 0); // Configuramos el AudioSource como corresponda
    //    sfxSource.mute = !(mute == 0);
    //    //if (mute == 1)
    //    //{
    //    //    toggle.isOn = true;
    //    //}
    //    //else
    //    //{
    //    //    toggle.isOn = false;
    //    //}
    //}

    void Update()
    {
#if OLD_SETTINGS
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoreVolume();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            LessVolume();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            MuteMusic();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            MuteMusic();
        }
#endif
    }


    //public void MuteMusic()
    //{

    //    musicSource.mute = !musicSource.mute;
    //    sfxSource.mute = !sfxSource.mute;

    //    PlayerPrefs.SetInt("MuteAll", musicSource.mute == true ? 0 : 1);
    //    Debug.Log("playerprefs2 "+PlayerPrefs.GetInt("MuteAll"));
    //    Debug.Log("Yolo");
    //}
#if OLD_SETTINGS
    // Método para subir y bajar el volumen en base al slider. Se
    // llama desde OnValueChanged() del GameObject con el Slider
    public void MoreVolume()
    {
        // Configuramos el volumen con el valor del slider
        changeVolume += 10;
        audioSource.volume = (float)changeVolume / 100;
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
        volumeText.text = $"Volume:{changeVolume}";
    }

    public void LessVolume()
    {
        // Configuramos el volumen con el valor del slider
        changeVolume -= 10;
        audioSource.volume = (float)changeVolume / 100;
        Debug.Log(changeVolume / 100);
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
        volumeText.text = $"Volume:{changeVolume}";
    }
#else
    public void ChangeVolumeMusic()
    {
        // Configuramos el volumen con el valor del slider
        musicSource.volume = sliderMusic.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
    }
    public void ChangeVolumeSFX()
    {
        // Configuramos el volumen con el valor del slider
        sfxSource.volume = sliderSFX.value;
        sfxSource2.volume = sliderSFX.value;
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
    }

#endif
    public void SaveSettings()
    { // Metodo para guardar los PlayerPrefs
        PlayerPrefs.Save(); // Guarda los PlayerPrefs
    }
}
