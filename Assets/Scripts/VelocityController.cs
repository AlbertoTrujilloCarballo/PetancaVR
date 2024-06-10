using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    private Rigidbody rb;
    public float targetSpeed; // Velocidad espec�fica a comparar
    public float decelerationRate = 5f; // Tasa de desaceleraci�n

    // Start is called antes de la primera actualizaci�n del frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Compara la magnitud de la velocidad actual con la velocidad objetivo
        if (rb.velocity.magnitude <= targetSpeed)
        {
            // Aplica una desaceleraci�n adicional
            rb.velocity *= Mathf.Max(0, 1 - decelerationRate * Time.deltaTime);

            // Establece la velocidad a cero si es muy peque�a
            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
