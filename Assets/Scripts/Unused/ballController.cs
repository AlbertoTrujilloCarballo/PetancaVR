using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    // Declaración del delegado
    public delegate void playerOneTurn();
    // Definición del evento
    public static event playerOneTurn changePlayerOneTurn;

    // Declaración del delegado
    public delegate void playerTwoTurn();
    // Definición del evento
    public static event playerTwoTurn changePlayerTwoTurn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When the object collides with another object
    private void OnTriggerEnter(Collider other)
    {

        if (other != null)
        {
            Debug.Log("kitipasa");
            // If the object is a ball
            if (other.gameObject.tag == "Point1")
            {
                // Destroy the ball
                //Destroy(other.gameObject);
                Debug.Log("Ha caido dentro");
                if (gameObject.tag == "Ball1")
                {
                    if (changePlayerOneTurn != null)
                    {
                        changePlayerOneTurn();
                    }
                }
                else if (gameObject.tag == "Ball2")
                {
                    if (changePlayerTwoTurn != null)
                    {
                        changePlayerTwoTurn();
                    }
                }
            }
            else if (other.gameObject.tag == "Point2")
            {
                Debug.Log("Ha caido fuera");
                if (gameObject.tag == "Ball1")
                {
                    if (changePlayerOneTurn != null)
                    {
                        changePlayerOneTurn();
                    }
                }
                else if (gameObject.tag == "Ball2")
                {
                    if (changePlayerTwoTurn != null)
                    {
                        changePlayerTwoTurn();
                    }
                }



            }
        }

    }
}
