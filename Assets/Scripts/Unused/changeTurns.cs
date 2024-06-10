using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTurns : MonoBehaviour
{
    bool player1Turn = true;
    bool player2Turn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player1Turn)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("Turno 1");
            }
        }
        else if (player2Turn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Turno 2");
            }
        }
    }

    // Nos suscribimos al evento cuando se habilita el objeto 
    private void OnEnable()
    {
        ballController.changePlayerOneTurn += changeTurnPlayerOne; // Suscribirse al evento
        ballController.changePlayerTwoTurn += changeTurnPlayerTwo; // Suscribirse al evento
    }
    // Nos damos de baja del evento cuando se deshabilita el objeto 
    private void OnDisable()
    {
        ballController.changePlayerOneTurn -= changeTurnPlayerOne; // Baja del evento
        ballController.changePlayerTwoTurn -= changeTurnPlayerTwo; // Baja del evento
    }

    void changeTurnPlayerOne()
    {
        player1Turn = true;
        player2Turn = false;
    }
    void changeTurnPlayerTwo()
    {
        player1Turn = false;
        player2Turn = true;
    }
}
