using UnityEngine;

public class HatChanger : MonoBehaviour
{

    // M�todo para cambiar el sombrero en la bola con el tag "ball1"
    public void ChangeHatForBall1(int hatIndex)
    {
        BallHat[] ballHats = FindObjectsOfType<BallHat>();
        // Llama al m�todo de equipar sombrero en el script de BallHat si est� disponible
        foreach (BallHat ballHat in ballHats)
        {
            if (ballHat.CompareTag("ball1"))
            {
                ballHat.EquipHat(hatIndex);
            }
        }
    }

        // M�todo para cambiar el sombrero en la bola con el tag "ball2"
        public void ChangeHatForBall2(int hatIndex)
        {
            // Llama al m�todo de equipar sombrero en el script de BallHat si est� disponible
            BallHat[] ballHats = FindObjectsOfType<BallHat>();
            // Llama al m�todo de equipar sombrero en el script de BallHat si est� disponible
            foreach (BallHat ballHat in ballHats)
            {
                if (ballHat.CompareTag("ball2"))
                {
                    ballHat.EquipHat(hatIndex);
                }
            }
        } 
}