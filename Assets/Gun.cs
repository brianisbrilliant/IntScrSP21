using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IItem
{
    [SerializeField]
    Transform bulletSpawn;

    void Start() {
        if(bulletSpawn == null) {
            bulletSpawn = this.transform.GetChild(0);
        }
    }
    // this function will be called from the PlayerController.
    public void Pickup(Transform hand) {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);             // make gun follow hand
        this.transform.localPosition = Vector3.zero;           // move gun to hand
        this.transform.localRotation = Quaternion.identity;    // make gun face forward same as hand
        this.GetComponent<Rigidbody>().isKinematic = true;     // make gun not fall
        this.GetComponent<Collider>().enabled = false;                                  // turn off gun's collider
        // other.GetComponent<Rigidbody>().enabled = false;     // if you still get pushed around, add this.
    }

    public void Use() {
        Debug.Log("<color=red>Pow!</color>");
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.localScale = Vector3.one * 0.15f;
        ball.transform.position = bulletSpawn.position;
        ball.transform.Translate(transform.forward);

        Rigidbody rb = ball.AddComponent<Rigidbody>();
        rb.AddForce(transform.forward * 50, ForceMode.Impulse);
    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0, 0, 2);              // move the gun forward 2 meters
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }
}
