using UnityEngine;

public class HatChanger : MonoBehaviour
{

    // Método para cambiar el sombrero en la bola con el tag "ball1"
    public void ChangeHatForBall1(int hatIndex)
    {
        BallHat[] ballHats = FindObjectsOfType<BallHat>();
        // Llama al método de equipar sombrero en el script de BallHat si está disponible
        foreach (BallHat ballHat in ballHats)
        {
            if (ballHat.CompareTag("ball1"))
            {
                ballHat.EquipHat(hatIndex);
            }
        }
    }

        // Método para cambiar el sombrero en la bola con el tag "ball2"
        public void ChangeHatForBall2(int hatIndex)
        {
            // Llama al método de equipar sombrero en el script de BallHat si está disponible
            BallHat[] ballHats = FindObjectsOfType<BallHat>();
            // Llama al método de equipar sombrero en el script de BallHat si está disponible
            foreach (BallHat ballHat in ballHats)
            {
                if (ballHat.CompareTag("ball2"))
                {
                    ballHat.EquipHat(hatIndex);
                }
            }
        } 
}