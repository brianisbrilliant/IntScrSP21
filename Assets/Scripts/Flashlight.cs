using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IItem
{
    
    [SerializeField]
    Light flashLight;

    bool canSwitchLight = true;

    // Start is called before the first frame update
    public void Pickup(Transform hand){
        this.gameObject.transform.SetParent(hand);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().enabled = false;
    }

    public void Use(){
        Debug.Log("Using our light");
        if(canSwitchLight){
            flashLight.enabled =!flashLight.enabled;
            canSwitchLight = false;
            StartCoroutine(Wait());
        }
    }

    public void Drop(){
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0,0,2);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }

    public void SecondaryUse() {
        
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.2f);
        canSwitchLight = true;
    }
}
