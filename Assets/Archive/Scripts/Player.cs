/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:Raycast to collect collectables and ui
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    /// <summary>
    /// setting ui elements to be called later on
    /// </summary>
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Tip;
    public TextMeshProUGUI Locked;
    public TextMeshProUGUI Tutorial;
    public GameObject screen;

    /// <summary>
    /// to display the welcome text
    /// </summary>
    void Start()
    {
        Tutorial.text =
            "Hi welcome to my game!! In this game you are trying to fix a Iron Giant while gaining coins. Have fun!!!!!!\nPress enter to start";
    }

    /// <summary>
    /// after the player preeses enter remove the text on screen and to remove the background
    /// </summary>
    void OnNext()
    {
        Tutorial.text = "";
        Destroy(screen);
    }
    void OnChangeView()
    {
    }

    /// <summary>
    /// this is a function to fire a raycast to update the ui ele
    /// </summary>
    public void Update()
    {
        ///<summary>
        /// creating raycast to find out what the player is seeing
        /// </summary>
        bool Raycast = Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            out RaycastHit hitInfo,
            5f
        );
        ///<summary>
        ///drawing a ray for debugging purposes
        /// </summary>
        Debug.DrawRay(
            transform.position,
            transform.TransformDirection(Vector3.forward) * 10f,
            Color.green
        );
        ///<summary>
        /// checking the output of the raycast to update ui
        /// </summary>
        if (Raycast)
        {
            if (hitInfo.collider.gameObject.name == "Door")
            {
                Debug.Log("looking at door");
                Tip.text = $"use E to open door";
            }
            else if (hitInfo.collider.gameObject.tag == "Collectable")
            {
                Debug.Log("looking at Collectable");
                Tip.text = $"use E to collect";
            }
        }
        else
        {
            Tip.text = $"";
            Locked.text = $"";
        }
        Points.text =
            $"Points : {gameObject.transform.parent.GetComponentInChildren<PlayerCollider>().playerScore}";
    }
    
    void OnUse()
    {
        ///<summary>
        /// creating raycast to find out what the player is seeing
        /// </summary>
        bool Raycast = Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.forward),
            out RaycastHit hitInfo,
            5f
        );
        ///<summary>
        /// calling functions
        /// </summary>
        if (Raycast)
        {
            ///<summary>
            /// open door if the player is looking at it
            /// </summary>
            if (hitInfo.collider.gameObject.CompareTag("Interactable"))
            {
                
            }
            
            
            
            if (hitInfo.collider.gameObject.name == "Door")
            {
                hitInfo
                    .collider.gameObject.transform.parent.gameObject.GetComponent<Door>()
                    .OpenDoor();
            }
            ///<summary>
            /// if the thing the raycast hits is a collectable collect it
            /// </summary>
            else if (hitInfo.collider.gameObject.tag == "Collectable")
            {
                if (hitInfo.collider.transform.parent.gameObject.name == "IronGiantHead")
                {
                    gameObject.transform.parent.GetComponentInChildren<PlayerCollider>().head =
                        true;
                    Destroy(hitInfo.collider.transform.parent.gameObject);
                }
                else if (hitInfo.collider.transform.parent.gameObject.name == "IronGiantLegs")
                {
                    gameObject.transform.parent.GetComponentInChildren<PlayerCollider>().legs =
                        true;
                    Destroy(hitInfo.collider.transform.parent.gameObject);
                }
                else if (hitInfo.collider.transform.parent.gameObject.name == "IronGiantArms")
                {
                    gameObject.transform.parent.GetComponentInChildren<PlayerCollider>().arms =
                        true;
                    Destroy(hitInfo.collider.transform.parent.gameObject);
                }
                else if (hitInfo.collider.transform.parent.gameObject.name == "IronGiantTorso")
                {
                    gameObject.transform.parent.GetComponentInChildren<PlayerCollider>().torso =
                        true;
                    Destroy(hitInfo.collider.transform.parent.gameObject);
                }
            }
        }
    }
}
