using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    [SerializeField] GameObject PetancaBall1;// Start is called before the first frame update]
    [SerializeField] GameObject PetancaBall2;
    void Start()
    {

    }

    public void SpawnBalls()
    {
        Instantiate(PetancaBall1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(PetancaBall2, new Vector3(1, 0, 1), Quaternion.identity);
    }
}
