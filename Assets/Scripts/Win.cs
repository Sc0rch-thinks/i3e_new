/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:show ui when win condition met
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    /// <summary>
    /// setting ui elements to be called later
    /// </summary>
    public TextMeshProUGUI end;
    public TextMeshProUGUI Crosshair;

    /// <summary>
    /// to display a win message when the player reaches the win area and disable the crosshair
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        end.text = "You Win \n Thanks for playing";
        Crosshair.text = "";
    }
}
