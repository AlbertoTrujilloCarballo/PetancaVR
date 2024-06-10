using UnityEngine;
using System.Collections;

public class SandEffect : MonoBehaviour
{
    public GameObject sandParticlesPrefab; // Prefab del sistema de partículas
    private bool hasCollided = false;
    private HapticFeedbackController hapticFeedbackController;

    private void Start()
    {
        hapticFeedbackController = FindObjectOfType<HapticFeedbackController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con el suelo de arena
        if (collision.gameObject.CompareTag("PowerUpActivator") && !hasCollided)
        {
            AudioManager.instance.PlaySFX($"Sand");
            // Instancia el sistema de partículas en el punto de colisión
            ContactPoint contact = collision.contacts[0];
            
            Instantiate(sandParticlesPrefab, contact.point, Quaternion.Euler(-90,0,0));
            

            hapticFeedbackController.TriggerHapticFeedback();

            // Marca la bola como colisionada para evitar múltiples instanciaciones
            hasCollided = true;

            // Llama al método para hundir la bola
            StartCoroutine(SinkInSand());
        }
    }

    private IEnumerator SinkInSand()
    {
        float sinkAmount = 0.005f; // La cantidad que la bola se hundirá
        float sinkDuration = 0.25f; // La duración del hundimiento
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition - new Vector3(0, sinkAmount, 0);

        float elapsedTime = 0;
        while (elapsedTime < sinkDuration)
        {
            // Interpolamos solo la posición Y para no afectar el movimiento en X y Z
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(originalPosition.y, targetPosition.y, elapsedTime / sinkDuration), transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que la posición final sea exacta
        transform.position = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
    }
}
