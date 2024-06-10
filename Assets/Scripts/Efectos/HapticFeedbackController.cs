using UnityEngine;
using Oculus.Interaction;
using Oculus.Platform;
using Oculus.Platform.Models;
using System.Collections;

public class HapticFeedbackController : MonoBehaviour
{
    // Duración y amplitud de la vibración
    public float vibrationDuration = 0.5f;
    public float vibrationFrequency = 0.8f;
    public float vibrationAmplitude = 0.5f;

    // Llama a esta función para iniciar la vibración
    public void TriggerHapticFeedback()
    {
        // Controlador derecho
        OVRInput.SetControllerVibration(vibrationFrequency, vibrationAmplitude, OVRInput.Controller.RTouch);

        // Controlador izquierdo
        OVRInput.SetControllerVibration(vibrationFrequency, vibrationAmplitude, OVRInput.Controller.LTouch);

        // Parar la vibración después de la duración especificada
        StartCoroutine(StopHapticFeedbackAfterDuration());
    }

    private IEnumerator StopHapticFeedbackAfterDuration()
    {
        yield return new WaitForSeconds(vibrationDuration);

        // Detener la vibración en ambos controladores
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
