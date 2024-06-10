using UnityEngine;

public class PUAttraction : MonoBehaviour
{
    public float maxAttractionForce = 30f; // La fuerza máxima de atracción cuando la distancia es mínima (0m)
    public float minAttractionForce = 5f; // La fuerza mínima de atracción cuando la distancia es máxima (4m)
    public float maxDistance = 4f; // La distancia máxima donde la fuerza es mínima
    public float duration = 5f; // La duración del power up
    public string targetTag = "PowerUpActivator"; // Tag del objeto que activa el power up
    public ParticleSystem particleEffect; // El sistema de partículas que se activará cuando el power-up esté activo

    private float timer = 0f;
    private bool activated = false;
    private bool power = true;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // El Rigidbody del objeto que tiene el power up
    }

    private void Update()
    {
        if (activated && power && rb.velocity == Vector3.zero)
        {
            timer += Time.deltaTime;
            rb.isKinematic = true;

            // Aplicar fuerza de atracción entre los objetos
            Rigidbody[] otherRigidbodies = FindObjectsOfType<Rigidbody>(); // Todos los Rigidbodies en la escena
            foreach (Rigidbody otherRb in otherRigidbodies)
            {
                if (otherRb != rb) // No queremos aplicar fuerza al objeto que tiene el power up
                {
                    float distance = Vector3.Distance(rb.position, otherRb.position);
                    if (distance > 0 && distance <= maxDistance) // Evitar división por cero y aplicar solo si la distancia está dentro del rango
                    {
                        Vector3 direction = (rb.position - otherRb.position).normalized;
                        float forceMagnitude = Mathf.Lerp(maxAttractionForce, minAttractionForce, distance / maxDistance);
                        otherRb.AddForce(direction * forceMagnitude);
                    }
                }
            }

            if (timer >= duration)
            {
                DeactivatePowerUp();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene el tag especificado
        if (collision.gameObject.CompareTag(targetTag))
        {
            rb.drag = 5.0f;
            ActivatePowerUp();
            AudioManager.instance.PlaySFX($"Attraction");
        }
    }

    // Método para activar el power up
    public void ActivatePowerUp()
    {
        activated = true;
        timer = 0f; // Reiniciar el temporizador al activar el power-up
        if (particleEffect != null)
        {
            particleEffect.Play(); // Reproducir el sistema de partículas
        }
    }

    // Método para desactivar el power up
    private void DeactivatePowerUp()
    {
        activated = false;
        timer = 0f;
        power = false;
        rb.isKinematic = false;
        if (particleEffect != null)
        {
            particleEffect.Stop(); // Detener el sistema de partículas
        }
    }
}
