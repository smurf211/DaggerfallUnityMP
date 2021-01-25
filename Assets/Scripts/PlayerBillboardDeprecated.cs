using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBillboardDeprecated : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position, -Vector3.up);
        Vector3 v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(Camera.main.transform.position - v); 

    }
}
