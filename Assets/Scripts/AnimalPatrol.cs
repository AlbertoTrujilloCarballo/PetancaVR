//#define oldCode
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalPatrol : MonoBehaviour
{
#if oldCode
    Vector3 destination;
    public Vector3 min, max;
    // Start is called before the first frame update
    void Start()
    {
        destination = RandomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
        Debug.Log(destination);
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("transform "+transform.position);
        //Debug.Log("destination "+destination);
        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 5, Random.Range(min.z, max.z));
    }
#else
    public Transform routeFather;
    int indexChildren;
    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = routeFather.GetChild(indexChildren).position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
        Debug.Log(destination);
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("transform "+transform.position);
        //Debug.Log("destination "+destination);
        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            indexChildren++;
            if(indexChildren >= routeFather.childCount) indexChildren = 0;
            destination = routeFather.GetChild(indexChildren).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }
#endif
}
