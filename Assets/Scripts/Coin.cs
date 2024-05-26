/*
* Author:Lin Hengrui RYan
* Date:13/5/24
* Description:Collectable(coin)
*/

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Coin : Collectable
{

        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Collect(other.gameObject, 10);
        }
    }
}
