using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IItem
{
    
    [SerializeField]
    Transform FirePoint;

     [SerializeField] GameObject bullet;

     bool gunIsFiring = true;
    
    //this function will be called from the player controller
    void Start() {
        if(FirePoint == null){
            FirePoint = this.transform.GetChild(0);
        }
    }

    public void Pickup(Transform hand) {
        this.gameObject.transform.SetParent(hand);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().enabled = false;
    }

    public void Use() {
        Debug.Log("<color=red>Pow!</color>");
        //Transform FirePoint;
        //firePoint = GameObject.Find("FirePoint").transform;
        if(gunIsFiring){
            //gunIsFiring.enabled = =!gunIsFiring.enabled;
            bullet = Instantiate(bullet, FirePoint.position, FirePoint.rotation, null);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            gunIsFiring = false;
            StartCoroutine(Wait());        }
        

    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0,0,2);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(1);
        gunIsFiring = true;
    }
}
