/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:open door
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    /// <summary>
    /// variables that concern doors
    /// </summary>
    bool IsOpen = false;
    public bool IsLocked = true;
    public TextMeshProUGUI Locked;

    /// <summary>
    /// function to open door
    /// </summary>
    public void OpenDoor()
    {
        if (!IsLocked)
        {
            if (!IsOpen)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y -= 90;
                transform.eulerAngles = currentRotation;
                IsOpen = true;
            }
            else
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y += 90;
                transform.eulerAngles = currentRotation;
                IsOpen = false;
            }
        }
        /// <summary>
        /// updating ui fdoor is locked
        /// </summary>
        else
        {
            Locked.text = "This door is locked please find the collectables";
        }
    }

    /// <summary>
    /// /// to check the collectables are collect and then unlock the door
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (IsLocked)
        {
            if (
                other.gameObject.GetComponent<PlayerCollider>().head == true
                && other.gameObject.GetComponent<PlayerCollider>().torso == true
                && other.gameObject.GetComponent<PlayerCollider>().arms == true
                && other.gameObject.GetComponent<PlayerCollider>().legs == true
            )
            {
                IsLocked = false;
            }
        }
    }

    /// <summary>
    /// to close the door when the door is far from the player
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        if (IsOpen && other.gameObject.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
}
