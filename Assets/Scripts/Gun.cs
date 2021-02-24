using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public void Pickup(Transform hand) 
    {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);         // make gun follow hand
        this.transform.localPosition = Vector3.zero;       // move gun to hand
        this.transform.loctaionRotation = Quaternion.identity;
        this.GetComponent<Rigidbody>().isKinematic = true; // make gun face forward same as hand
        this.GetComponent<Collider>().enabled = false;  // turn off gun's collider
    }

    public void Use()
    {
        Debug.Log("<color=red>Pow!</color>");
    }

    public void Drop()
    {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0, 0, 2);
        this.GetComponent<RigidBody>().isKinematic = false;
        this.GetComponent<RigidBody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }
}
