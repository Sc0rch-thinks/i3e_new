/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:Store variables
*/


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    /// <summary>
    /// this is to set the player score
    /// </summary>
    public int playerScore = 0;

    /// <summary>
    /// these variables checks if the collectables heve been collected
    /// </summary>
    public bool head = false;
    public bool torso = false;
    public bool arms = false;
    public bool legs = false;

    /// <summary>
    /// function to the player score
    /// </summary>
    /// <param name="scoreToAdd">the amount of points that the player should be awarded</param> <summary>
    /// </summary>
    public void IncreaseScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
    }
}
