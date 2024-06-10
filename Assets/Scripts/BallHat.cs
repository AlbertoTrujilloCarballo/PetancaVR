using UnityEngine;

public class BallHat : MonoBehaviour
{
    // Arreglo de prefabs de sombreros
    public GameObject[] hats;

    // �ndice del sombrero actualmente equipado
    private int currentHatIndex = 0;

    // Referencia al sombrero actualmente equipado
    private GameObject currentHat;

    // Offset de posici�n del sombrero respecto al objeto
    public Vector3 hatOffset = new Vector3(0f, 1f, 0f);

    void Start()
    {
        // Al inicio, equipa el primer sombrero de la lista
        EquipHat(currentHatIndex);
    }

    // M�todo para cambiar el sombrero
    public void ChangeHat()
    {
        // Incrementa el �ndice del sombrero
        currentHatIndex++;

        // Si el �ndice es mayor que la cantidad de sombreros, vuelve al primero
        if (currentHatIndex >= hats.Length)
        {
            currentHatIndex = 0;
        }

        // Equipa el sombrero correspondiente al nuevo �ndice
        EquipHat(currentHatIndex);
    }

    // M�todo para equipar un sombrero dado un �ndice
    public void EquipHat(int index)
    {
        // Destruye el sombrero actual si existe
        if (currentHat != null)
        {
            Destroy(currentHat);
        }

        // Instancia el nuevo sombrero y lo asigna como hijo del objeto actual
        currentHat = Instantiate(hats[index], transform.position + hatOffset, Quaternion.identity);
        currentHat.transform.parent = transform;
    }

    void LateUpdate()
    {
        // Asegura que el sombrero siempre est� encima del objeto incluso si el objeto rota
        if (currentHat != null)
        {
            // Mantener la rotaci�n del sombrero independiente de la rotaci�n del objeto padre
            currentHat.transform.rotation = Quaternion.Euler(Vector3.zero);
            currentHat.transform.position = transform.position + hatOffset;
        }
    }
}
