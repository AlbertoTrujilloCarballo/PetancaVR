using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class checkDistance : MonoBehaviour
{
    // Etiquetas de los objetos de pelota
    public string ball1Tag = "ball1";
    public string ball2Tag = "ball2";

    [SerializeField] TextMeshProUGUI distanciaTexto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checkDistanceBetweenBalls();
    }

    public string checkDistanceBetweenBalls()
    {
        // Buscar los GameObjects de las pelotas por etiqueta
        GameObject[] ball1Objects = GameObject.FindGameObjectsWithTag(ball1Tag);
        GameObject[] ball2Objects = GameObject.FindGameObjectsWithTag(ball2Tag);

        

        if (ball1Objects.Length == 0)
        {
            Debug.LogError("No se encontraron objetos con la etiqueta ball1");
            //return;
        }

        if (ball2Objects.Length == 0)
        {
            Debug.LogError("No se encontraron objetos con la etiqueta ball2");
            //return;
        }

        // Obtener la posición del objeto que lleva el script
        Vector3 playerPosition = transform.position;

        // Calcular la distancia entre el objeto y las pelotas más cercanas
        float closestDistanceToBall1 = float.MaxValue;
        float closestDistanceToBall2 = float.MaxValue;

        foreach (GameObject ball1Object in ball1Objects)
        {
            float distanceToBall1 = Vector3.Distance(playerPosition, ball1Object.transform.position);
            if (distanceToBall1 < closestDistanceToBall1)
            {
                closestDistanceToBall1 = distanceToBall1;
            }
        }

        foreach (GameObject ball2Object in ball2Objects)
        {
            float distanceToBall2 = Vector3.Distance(playerPosition, ball2Object.transform.position);
            if (distanceToBall2 < closestDistanceToBall2)
            {
                closestDistanceToBall2 = distanceToBall2;
            }
        }

        // Comparar las distancias y determinar cuál es más cercana
        if (closestDistanceToBall1 < closestDistanceToBall2)
        {
            closestDistanceToBall1 = Mathf.Round(closestDistanceToBall1 * 100f) / 100f;
            distanciaTexto.text = "Distancia: " + closestDistanceToBall1.ToString() + "m";
            return "Ball1";
        }
        else if (closestDistanceToBall2 < closestDistanceToBall1)
        {
            closestDistanceToBall2 = Mathf.Round(closestDistanceToBall2 * 100f) / 100f;
            distanciaTexto.text = "Distancia: " + closestDistanceToBall2.ToString() + "m";
            return "Ball2";
        }
        else
        {
            return "Both";
        }
    }
}
