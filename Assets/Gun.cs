using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //this function will be called from the player controller
    public void Pickup(Transform hand) {
        this.gameObject.transform.SetParent(hand);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().enabled = false;
    }

    public void Use(GameObject Bullet) {
        Debug.Log("<color=red>Pow!</color>");
        Transform firePoint;
        firePoint = GameObject.Find("FirePoint").transform;
        GameObject bullet;
        bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation, null);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200);

    }

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0,0,2);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }
}
