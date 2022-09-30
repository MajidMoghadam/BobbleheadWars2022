using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet", 0f, 0.1f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }

    void fireBullet()
    {
        //create a new bullet object from the prefab
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        //placing the bullet at the Launcher position
        bullet.transform.position = launchPosition.position;
        //giving the bullet an initial velocity to take off with
        bullet.GetComponent<Rigidbody>().velocity =
        this.transform.parent.forward * 100;
    }

}
