using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IAController : MonoBehaviour
{
    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;

    private float leftMax = -21.625f;
    private float rightMax = -20.86f;

    private float minForce = 40;
    private float maxForce = 100f;

    private Vector3 randomTransform;
    private float randomX;

    [SerializeField] List<GameObject> balls = new();
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        EndGame.ChangeTurnCheck += startTurn;

    }
    private void OnDisable()
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
            case 2:case 1:
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
        yield return new WaitForSeconds(1);
        selectBall();
        ball.GetComponent<Rigidbody>().isKinematic = true;
        //ball.GetComponent<Rigidbody>().useGravity = false;
        randomX = Random.Range(leftMax, rightMax);
        randomTransform = new Vector3(randomX, transform.position.y, transform.position.z);
        ball.transform.position = randomTransform;
        yield return new WaitForSeconds(5);
        if(ball.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            throwBall();
        }
        
    }

    private void throwBall()
    {
        ball.GetComponent<Rigidbody>().isKinematic = false;
        //ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }
}
