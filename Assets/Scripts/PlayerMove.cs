using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;






namespace DaggerfallWorkshop.Game
{
    public class PlayerMove : NetworkBehaviour
    {

        [SyncVar(hook = nameof(OnHolaCountChanged))]
        int holaCount = 0;

       
        private GameObject playerAdvancedObj = null;
       
        private GameObject playerUnitObj = null;

        void HandleMovement()
        {
            if (isLocalPlayer)
            {



                if (playerAdvancedObj != null)
                {
                    Vector3 playerAdvancedPosition = playerAdvancedObj.transform.position;
                    transform.position = playerAdvancedPosition;
                }
                //Debug.Log("Player Advanced Pos: " + playerAdvancedPosition);
                // playerAdvancedPosition.x = playerAdvancedPosition.x ;
                //playerAdvancedPosition.y = playerAdvancedPosition.y + 1f;
                



                // Debug.Log("IS LOCAL PLAYER!!");

                //float moveHorizontal = Input.GetAxis("Horizontal");
                //float moveVertical = Input.GetAxis("Vertical");
                //Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
               //transform.position = transform.position + movement;
           
                
                
                

            }
            else{
               
                
                
            }
        }

        void Update()
        {
            //playerAdvancedObj = GameObject.Find("PlayerAdvanced");
            
            //playerUnitObj = GameObject.Find("PlayerUnit(Clone)");

            HandleMovement();
            if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("sending hola to server!");
                Hola();
               
            }
             
        //Debug.Log("Player Position: X = " + playerAdvancedObj.transform.position.x + " --- Y = " + playerAdvancedObj.transform.position.y + " --- Z = " + 
        // playerAdvancedObj.transform.position.z);

       //  Debug.Log("Player Position: X = " + playerUnitObj.transform.position.x + " --- Y = " + playerUnitObj.transform.position.y + " --- Z = " + 
        // playerUnitObj.transform.position.z);

         


        }

      

        public override void OnStartServer()
        {
            Debug.Log("Player has been spawned on the server!");
            /*
            if (isLocalPlayer)
            {
                playerAdvancedObj = GameObject.Find("PlayerAdvanced");
                playerUnitObj = GameObject.Find("PlayerUnit(Clone)");
            }

*/




        }

        public override void OnStartClient(){

            if (isLocalPlayer)
            {
                playerAdvancedObj = GameObject.Find("PlayerAdvanced");
                //playerUnitObj = GameObject.Find("PlayerUnit(Clone)");
                playerUnitObj = GameObject.Find("PlayerSprite(Clone)");

                Vector3 playerAdvancedPosition = playerAdvancedObj.transform.position;
                playerAdvancedPosition.x = playerAdvancedPosition.x -2f;
                playerUnitObj.transform.position = playerAdvancedPosition;
            }

            
              
            //for(int i =0; i < playerUnitObj.Length; i++){
           // Debug.Log("THE ARRAY OF THE PLAYERUNIT " + playerUnitObj[i].ToString());
          //  }
             
            
            
            
        }

        [Command]
        void Hola()
        {
            Debug.Log("recieved hola from client!");
            holaCount += 1;
            ReplyHola();
        }

        [TargetRpc]
        void ReplyHola()
        {
            Debug.Log("Received hola from server");
        }

        [TargetRpc]
        void getPlayerAdvPos()
        {
            Debug.Log("Received hola from server");
        }

        [ClientRpc] //ALL CLIENTS TargetRpc on one client
        void TooHigh()
        {
            Debug.Log("Too high");
        }

        void OnHolaCountChanged(int oldCount, int newCount)
        {
            Debug.Log($"WE had {oldCount} holas, but now we have {newCount} holas!");
        }


    }
}