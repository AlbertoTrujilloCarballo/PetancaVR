using UnityEngine;

public class BallHat : MonoBehaviour
{
    // Arreglo de prefabs de sombreros
    public GameObject[] hats;

    // Índice del sombrero actualmente equipado
    private int currentHatIndex = 0;

    // Referencia al sombrero actualmente equipado
    private GameObject currentHat;

    // Offset de posición del sombrero respecto al objeto
    public Vector3 hatOffset = new Vector3(0f, 1f, 0f);

    void Start()
    {
        // Al inicio, equipa el primer sombrero de la lista
        EquipHat(currentHatIndex);
    }

    // Método para cambiar el sombrero
    public void ChangeHat()
    {
        // Incrementa el índice del sombrero
        currentHatIndex++;

        // Si el índice es mayor que la cantidad de sombreros, vuelve al primero
        if (currentHatIndex >= hats.Length)
        {
            currentHatIndex = 0;
        }

        // Equipa el sombrero correspondiente al nuevo índice
        EquipHat(currentHatIndex);
    }

    // Método para equipar un sombrero dado un índice
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
        // Asegura que el sombrero siempre esté encima del objeto incluso si el objeto rota
        if (currentHat != null)
        {
            // Mantener la rotación del sombrero independiente de la rotación del objeto padre
            currentHat.transform.rotation = Quaternion.Euler(Vector3.zero);
            currentHat.transform.position = transform.position + hatOffset;
        }
    }
}
