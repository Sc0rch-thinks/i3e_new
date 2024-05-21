/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:Collectable(coin)
*/

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /// <summary>
    /// creating a variable to declare the value of the coin
    /// </summary>
    public int collecableValue = 10;

    /// <summary>
    /// making a function where the player touches a coin to add their score
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCollider>().IncreaseScore(collecableValue);
            Destroy(gameObject);
        }
    }
}
