using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public virtual void Collect(GameObject other, int collectableValue)
    {
        other.GetComponent<PlayerCollider>().IncreaseScore(collectableValue);
        Destroy(gameObject);
    }





}
