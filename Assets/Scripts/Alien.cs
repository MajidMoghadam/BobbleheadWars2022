using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour
{
    public Transform target;    //where the alien must go towards
    private NavMeshAgent agent; //reference to the Alien

    public float navigationUpdate;  //time in ms when alien should update its path
    private float navigationTime = 0;   //how much time has passed since the previous update

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
            //accumulates time since last update of path
            navigationTime += Time.deltaTime;
            //if its time to update
            if (navigationTime > navigationUpdate)
            {
                //this tells the agent where to go
                agent.destination = target.position;
                navigationTime = 0;
            }
        }
    }
}
