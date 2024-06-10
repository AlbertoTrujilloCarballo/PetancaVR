using UnityEngine;

public class Levitation : MonoBehaviour
{
    // Variables para controlar la animaci�n
    public float amplitude = 0.5f; // Altura m�xima de la levitaci�n
    public float frequency = 1f;   // Velocidad de la levitaci�n

    // Posici�n inicial del objeto
    private Vector3 startPos;

    void Start()
    {
        // Guardamos la posici�n inicial
        startPos = transform.position;
    }

    void Update()
    {
        // Calculamos la nueva posici�n
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;

        // Aplicamos la nueva posici�n
        transform.position = tempPos;
    }
}

