using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject terrain;
    [SerializeField] checkDistance checkDistance;
    [SerializeField] ScoreManager ScoreManager;
    [SerializeField] GameObject endGameDialog;
    [SerializeField] GameObject RedWin;
    [SerializeField] GameObject GreenWin;
    [SerializeField] GameObject Draw;
    public string ball1Tag = "ball1";
    public string ball2Tag = "ball2";
    private HashSet<GameObject> ball1Objects = new HashSet<GameObject>();
    private HashSet<GameObject> ball2Objects = new HashSet<GameObject>();
    private HashSet<GameObject> ball1Vel = new HashSet<GameObject>();
    private HashSet<GameObject> ball2Vel = new HashSet<GameObject>();
    private bool gameEnded = false;
    public delegate void ChangeTurn();
    public static event ChangeTurn ChangeTurnCheck;

    [SerializeField] List<GameObject> handleGrabs = new List<GameObject>();

    void Start()
    {

        // Obtener todas las bolas con el tag ball1 y ball2 en la escena
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag(ball1Tag);
        foreach (GameObject obj in allObjects)
        {
            ball1Objects.Add(obj);
        }

        allObjects = GameObject.FindGameObjectsWithTag(ball2Tag);
        foreach (GameObject obj in allObjects)
        {
            ball2Objects.Add(obj);
        }

        // Obtener todas las bolas con el tag ball1 y ball2 en la escena
        GameObject[] allVels = GameObject.FindGameObjectsWithTag(ball1Tag);
        foreach (GameObject obj in allVels)
        {
            ball1Vel.Add(obj);
        }

        allVels = GameObject.FindGameObjectsWithTag(ball2Tag);
        foreach (GameObject obj in allVels)
        {
            ball2Vel.Add(obj);
        }
    }

    private void Update()
    {
        if (AllBallsStopped())
        {
            CheckGameEnd();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (ball1Objects.Contains(collidedObject))
        {
            ball1Objects.Remove(collidedObject);
        }
        else if (ball2Objects.Contains(collidedObject))
        {
            ball2Objects.Remove(collidedObject);
            if (ChangeTurnCheck != null)
            {
                ChangeTurnCheck();
            }
        }
    }

    void CheckGameEnd()
    {
        if (!gameEnded && ball1Objects.Count == 0 && ball2Objects.Count == 0)
        {
            AudioManager.instance.PlaySFX($"Cry");
            endGameDialog.SetActive(true);
            string ganador = checkDistance.checkDistanceBetweenBalls();
            

            if (ganador == "Ball1") { GreenWin.SetActive(true); ScoreManager.UpdateScoreGreen(); }
            if (ganador == "Ball2") { RedWin.SetActive(true); ScoreManager.UpdateScoreRed();
            }
            if (ganador == "Both") { Draw.SetActive(true); }
            gameEnded = true;

            Invoke("RestartScene", 4f);

        }
    }

    // M�todo para reiniciar la escena
    void RestartScene()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Reiniciar la escena
        SceneManager.LoadScene(currentSceneName);
    }

    bool AllBallsStopped()
    {
        foreach (GameObject ball in ball1Vel)
        {
            if (ball.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                return false;
            }
        }

        foreach (GameObject ball in ball2Vel)
        {
            if (ball.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                return false;
            }
        }

        return true;
    }
    public void SetKinematic(bool value)
    {
        foreach (GameObject obj in handleGrabs)
        {
            obj.SetActive(value);
        }
    }
}
