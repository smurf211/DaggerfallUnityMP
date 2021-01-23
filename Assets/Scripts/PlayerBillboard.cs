using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBillboard : NetworkBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}
