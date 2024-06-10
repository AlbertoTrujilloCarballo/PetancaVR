using UnityEngine;

public class BallGrabber : MonoBehaviour
{
    private bool isGrabbing = false;
    private HapticFeedbackController hapticFeedbackController;

    private void Start()
    {
        hapticFeedbackController = FindObjectOfType<HapticFeedbackController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("ball2")) && !isGrabbing)
        {
            isGrabbing = true;
            hapticFeedbackController.TriggerHapticFeedback();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ball2"))
        {
            isGrabbing = false;
        }
    }
}
