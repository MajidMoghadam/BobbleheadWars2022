using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public Transform target;    //where the alien must go towards
    private NavMeshAgent agent; //

    // Start is called before the first frame update
    void Start()
    {
        //gets a reference to the NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //this tells the agent where to go
            agent.destination = target.position;
        }
    }
}
