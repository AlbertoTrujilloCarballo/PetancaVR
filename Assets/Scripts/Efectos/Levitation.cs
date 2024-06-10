using UnityEngine;

public class Levitation : MonoBehaviour
{
    // Variables para controlar la animación
    public float amplitude = 0.5f; // Altura máxima de la levitación
    public float frequency = 1f;   // Velocidad de la levitación

    // Posición inicial del objeto
    private Vector3 startPos;

    void Start()
    {
        // Guardamos la posición inicial
        startPos = transform.position;
    }

    void Update()
    {
        // Calculamos la nueva posición
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;

        // Aplicamos la nueva posición
        transform.position = tempPos;
    }
}

