using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAdvancedFix : NetworkBehaviour
{   

    
    // Start is called before the first frame update
    void Awake()
    {
        //NetworkServer.Spawn(this);
        
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    
}
