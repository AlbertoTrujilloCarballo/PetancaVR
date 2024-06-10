using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IAControllerHand : MonoBehaviour
{
    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;

    public float leftMax = -21.625f;
    public float rightMax = -20.86f;

    public float minForce = 40;
    public float maxForce = 100f;

    public GameObject handPrefab; // Prefab de la mano
    public float handOffsetX = 0f; // Offset de la mano en X
    public float handOffsetY = 0f; // Offset de la mano en Y
    public float handOffsetZ = -0.2f; // Offset de la mano en Z
    public float handAnimationTime = 0.5f; // Tiempo de la animación de la mano
    public float handArcHeight = 0.5f; // Altura del arco de la mano

    private Vector3 randomTransform;
    private float randomX;

    [SerializeField] List<GameObject> balls = new();
    private GameObject ball;
    private GameObject hand; // Instancia de la mano
    public EndGame playerballs;

    void Start()
    {
        // Instanciamos la mano
        hand = Instantiate(handPrefab);
        hand.SetActive(false); // La desactivamos por defecto
    }

    void OnEnable()
    {
        EndGame.ChangeTurnCheck += startTurn;
    }

    void OnDisable()
    {
        EndGame.ChangeTurnCheck -= startTurn;
    }

    void startTurn()
    {
        StartCoroutine(completeTurn());
    }

    void selectBall()
    {

        switch (balls.Count)
        {

            case 4:
                ball = balls[Random.Range(1, 4)];
                ball.GetComponent<Rigidbody>();
                balls.Remove(ball);
                break;
            case 3:
                ball = balls[Random.Range(0, 3)];
                ball.GetComponent<Rigidbody>();
                balls.Remove(ball);
                break;
            case 2:
            case 1:
                ball = balls[0];
                ball.GetComponent<Rigidbody>();
                balls.Remove(ball);
                break;
            default:
                break;
        }
    }

    IEnumerator completeTurn()
    {
        playerballs.SetKinematic(false);
        yield return new WaitForSeconds(1);
        selectBall();
        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
            randomX = Random.Range(leftMax, rightMax);
            randomTransform = new Vector3(randomX, transform.position.y, transform.position.z);
            ball.transform.position = randomTransform;

            // Activar y posicionar la mano
            hand.SetActive(true);
            Vector3 handPosition = ball.transform.position + new Vector3(handOffsetX, handOffsetY, handOffsetZ);
            hand.transform.position = handPosition;
            hand.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotar la mano 90 grados en el eje Y

            yield return new WaitForSeconds(5);

            if (ball.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                playerballs.SetKinematic(true);
                throwBall();
            }
        }
    }

    private void throwBall()
    {
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(minForce, maxForce), ForceMode.Impulse);

        // Mover la mano con la bola (animación orgánica)
        StartCoroutine(MoveHandWithBall());
    }

    IEnumerator MoveHandWithBall()
    {
        float elapsedTime = 0f;

        Vector3 initialPosition = hand.transform.position;
        Vector3 finalPosition = ball.transform.position + ball.transform.up * 0.5f; // Ajusta según la trayectoria deseada

        while (elapsedTime < handAnimationTime)
        {
            float t = elapsedTime / handAnimationTime;
            float height = Mathf.Sin(Mathf.PI * t) * handArcHeight; // Crea un arco usando una función seno

            // Interpolación de la posición de la mano
            Vector3 currentPosition = Vector3.Lerp(initialPosition, finalPosition, t);
            currentPosition.y += height;

            hand.transform.position = currentPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Desactivar la mano después del lanzamiento
        hand.SetActive(false);
    }
}
