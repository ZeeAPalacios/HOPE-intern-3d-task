using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximityDoorScript : MonoBehaviour
{

    Vector3 startPos;
    Vector3 startRot;
    public Vector3 openedDoorPos;
    public Vector3 openedDoorRot;

    float lerpIncrement;

    public string doorState = "closed";

    // Start is called before the first frame update


    void Awake() {
        doorState = "closed";
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
        else {
            lerpIncrement += Time.deltaTime;
        }

        
        if (lerpIncrement > 1) {
            lerpIncrement = 1;
        }

        if (lerpIncrement < 0) {
            lerpIncrement = 0;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            doorState = "open";
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            doorState = "closed";
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
