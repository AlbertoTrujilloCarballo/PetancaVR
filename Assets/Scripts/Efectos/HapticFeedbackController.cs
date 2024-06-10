using UnityEngine;
using Oculus.Interaction;
using Oculus.Platform;
using Oculus.Platform.Models;
using System.Collections;

public class HapticFeedbackController : MonoBehaviour
{
    // Duraci�n y amplitud de la vibraci�n
    public float vibrationDuration = 0.5f;
    public float vibrationFrequency = 0.8f;
    public float vibrationAmplitude = 0.5f;

    // Llama a esta funci�n para iniciar la vibraci�n
    public void TriggerHapticFeedback()
    {
        // Controlador derecho
        OVRInput.SetControllerVibration(vibrationFrequency, vibrationAmplitude, OVRInput.Controller.RTouch);

        // Controlador izquierdo
        OVRInput.SetControllerVibration(vibrationFrequency, vibrationAmplitude, OVRInput.Controller.LTouch);

        // Parar la vibraci�n despu�s de la duraci�n especificada
        StartCoroutine(StopHapticFeedbackAfterDuration());
    }

    private IEnumerator StopHapticFeedbackAfterDuration()
    {
        yield return new WaitForSeconds(vibrationDuration);

        // Detener la vibraci�n en ambos controladores
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
