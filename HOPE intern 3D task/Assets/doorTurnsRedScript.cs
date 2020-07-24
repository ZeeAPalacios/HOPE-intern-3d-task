using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTurnsRedScript : MonoBehaviour
{

    MeshRenderer rend;


    void Start()
    {
        rend = this.GetComponent<MeshRenderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<MeshRenderer>().enabled = rend.enabled;
    }


    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            rend.enabled = false;
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            rend.enabled = true;
        }
    }
}
