using UnityEngine;

public class LanzamientoParabolico : MonoBehaviour
{
    // Velocidad inicial del lanzamiento en m/s
    public float velocidadInicial = 5f;

    // Ángulo de lanzamiento en grados
    public float anguloLanzamiento = 45f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Convertimos el ángulo de grados a radianes
        float anguloRadianes = anguloLanzamiento * Mathf.Deg2Rad;

        // Calculamos las componentes x e y de la velocidad inicial
        float velocidadInicialX = velocidadInicial * Mathf.Cos(anguloRadianes);
        float velocidadInicialY = velocidadInicial * Mathf.Sin(anguloRadianes);

        // Aplicamos la fuerza inicial al Rigidbody
        Vector3 fuerzaInicial = new Vector3(velocidadInicialX, velocidadInicialY, 0f);
        rb.AddForce(fuerzaInicial, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        // Aplicar fuerza de gravedad constante hacia abajo
        rb.AddForce(Vector3.down * Physics.gravity.magnitude, ForceMode.Acceleration);
    }
}
