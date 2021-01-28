using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager 
{
    // Start is called before the first frame update
    private GameObject playerAdvancedObj = null;
    private GameObject gameManagerObj = null;
    public override void OnStartServer()
    {

                 //playerAdvancedObj = GameObject.Find("PlayerAdvanced");
                //playerUnitObj = GameObject.Find("PlayerUnit(Clone)");
               // gameManagerObj = GameObject.Find("GameManager");
               // NetworkServer.Spawn(playerAdvancedObj);
               // Debug.Log("Spawned player advanced & Game Manager");
               // NetworkServer.Spawn(gameManagerObj);

        Debug.Log("Server Started");
    }

    public override void OnStopServer()
    {
       
              
    
        Debug.Log("Server Stopped!");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Connected to server!");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Disconnected from server!");
    }
}
