using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDoorScript : MonoBehaviour
{

    Vector3 startPos;
    Vector3 startRot;
    public Vector3 openedDoorPos;
    public Vector3 openedDoorRot;

    float lerpIncrement;

    public string doorState = "closed";

    public bool playerIsLooking;
    void Awake()
    {
        doorState = "closed";
        playerIsLooking = false;
        startPos = this.transform.position;
        startRot = this.transform.rotation.eulerAngles;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(startPos, openedDoorPos, lerpIncrement);
        this.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, openedDoorRot, lerpIncrement));


        //print(this.transform.rotation.eulerAngles);

        if (doorState == "closed")
        {
            lerpIncrement -= Time.deltaTime;
        }
        else
        {
            lerpIncrement += Time.deltaTime;
        }


        if (lerpIncrement > 1)
        {
            lerpIncrement = 1;
        }

        if (lerpIncrement < 0)
        {
            lerpIncrement = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && playerIsLooking == true)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
                if (lerpIncrement == 0 || lerpIncrement == 1) {
                    if (doorState == "closed")
                    {
                        doorState = "open";
                    }
                    else
                    {
                        doorState = "closed";
                    }
                }                
            }            
        }
    }

    

    //void closedDoorLerpValuesSet() {
    //    lerpPosA = openedDoorPos;
    //    lerpPosB = startPos;
    //    lerpIncrement = 0;
    //}

    //void openedDoorLerpValuesSet() {
    //    lerpPosA = startPos;
    //    lerpPosB = openedDoorPos;
    //    lerpIncrement = 0;
    //}
}
