using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    private CharacterController characterController;
    public Rigidbody head;

    //Raycasting
    public LayerMask layerMask; //the layer the ray should hit
    private Vector3 currentLookTarget = Vector3.zero;  //

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(moveDirection * moveSpeed);
        //characterController.Move(moveDirection * moveSpeed);
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection == Vector3.zero)
        {
            // TODO
        }
        else
        {
            head.AddForce(transform.right * 150, ForceMode.Acceleration);
        }
        //creates an empty raycast, if you get a hit it'll be populated
        //with a value
        RaycastHit hit;
        //you cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //draws the ray in the scene view
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        //you cast a ray from physics object
        //the (out) hit variable is populated once the ray hits at object
        //1000 is the lenth of the ray
        //layerMask tells the Mask what you are trying to hit
        //QueryTriggerInteraction.Ignore tells physics engine not to activate triggers
        if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.point != currentLookTarget)
            {
                //update the currentLookTarget with the coordinates of the hit point
                currentLookTarget = hit.point;
            }

            // update target position, using "y"of Marine so it doesn't look towards floor
            Vector3 targetPosition = new Vector3(hit.point.x,
            transform.position.y, hit.point.z);
            // calculate the rotation needed for Marine to turn towards
            Quaternion rotation = Quaternion.LookRotation(targetPosition -
            transform.position);
            // Marine does actual turn gradually using Lerp
            transform.rotation = Quaternion.Lerp(transform.rotation,
            rotation, Time.deltaTime * 10.0f);
        }
    }

}
