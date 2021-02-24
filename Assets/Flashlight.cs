using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IItem
{
    [SerializeField]
    Light flashlight;

    bool canSwitchLight = true;             // the player can turn the flashlight on or off.

    public void Pickup(Transform hand) {
        Debug.Log("I am running the Pickup() method.");
        this.gameObject.transform.SetParent(hand);             // make gun follow hand
        this.transform.localPosition = Vector3.zero;           // move gun to hand
        this.transform.localRotation = Quaternion.identity;    // make gun face forward same as hand
        this.GetComponent<Rigidbody>().isKinematic = true;     // make gun not fall
        this.GetComponent<Collider>().enabled = false;                                  // turn off gun's collider
    }

    public void Use() {
        Debug.Log("Using our light!");
        if(canSwitchLight) {                // if canswitch is true...
            flashlight.enabled = !flashlight.enabled;       // switch the light
            canSwitchLight = false;         // disable canswitch    
            StartCoroutine(Wait());         // wait for 1 second
        }
    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0, 0, 2);              // move the gun forward 2 meters
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(.2f);     // wait for 1 second
        canSwitchLight = true;                  // make canswitch true again.
    }
}
