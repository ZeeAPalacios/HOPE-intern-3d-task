using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycastTest : MonoBehaviour
{
    
    public GameObject lastClickDoor;


    void Awake() {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rHit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rHit)) {

            if (rHit.transform.gameObject.tag == "Click Door")
            {
                lastClickDoor = rHit.transform.gameObject;
                lastClickDoor.GetComponent<clickDoorScript>().playerIsLooking = true;
            }
            else
            {
                if (lastClickDoor.gameObject != null) {
                    lastClickDoor.GetComponent<clickDoorScript>().playerIsLooking = false;
                }
                
            }

        }

        


        

    }
}
