using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class SpeedBoost : Collectable
{
    public override void Collect(GameObject other, int collectableValue)
    {
        other.gameObject.GetComponent<FirstPersonController>().MoveSpeed += 10.0f;
        base.Collect(other, collectableValue);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("called");
            Collect(other.gameObject, 10);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("called");
            Collect(other.gameObject, 10);
        }
    }
}
