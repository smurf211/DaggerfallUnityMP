using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBillboardDeprecated : NetworkBehaviour
 {
    private GameObject playerAdvancedObj = null;
 
    void Update() 
    {
       
            playerAdvancedObj = GameObject.Find("PlayerAdvanced");

            Vector3 playerAdvancedPosition = playerAdvancedObj.transform.position;

        var distance = playerAdvancedPosition - Camera.main.transform.position;
        //Debug.Log("DISTANCE TO CAMERA " + distance);

        if(isLocalPlayer && distance.x < 1){
        GetComponent<Renderer>().enabled = false;
         }
         else
          {
          GetComponent<Renderer>().enabled = true;


        Vector3 v = Camera.main.transform.position - transform.position;


            v.x = v.z = 0.0f;
            transform.LookAt(Camera.main.transform.position - v);
        }

    }
 }
