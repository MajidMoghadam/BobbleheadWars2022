using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mahe sure there is a target to follow
        if (followTarget != null)
        {
            //camera gradually moves towards target
            transform.position = Vector3.Lerp(transform.position,
            followTarget.transform.position, Time.deltaTime * moveSpeed*1);
        }
    }
}
