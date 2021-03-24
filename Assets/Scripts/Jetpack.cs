using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour, IItem
{
    
    [SerializeField]
    Transform FirePoint;

    [SerializeField] GameObject TBullet, player;


     //bool gunIsFiring = true;
     bool isFire = false;
    
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
        if (isFire){
            StartCoroutine(Wait());        
            } else {
                TBullet = Instantiate(TBullet, FirePoint.position, FirePoint.rotation, null);
                TBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
            } 
            isFire = !isFire;

            if(TBullet != null){
                Teleport();
            }
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
        isFire = !isFire;
    }

    public void Teleport()
    {
        
        player.transform.position = TBullet.transform.position;
        player.transform.Translate(Vector3.up);
    }

    public void SecondaryUse() {
        
    }
}