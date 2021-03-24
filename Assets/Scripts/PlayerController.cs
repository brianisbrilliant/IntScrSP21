using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coins; 
    IItem heldItem;
    public int totalKeys;

    [SerializeField] AudioClip doorOpen; AudioSource aud;
    // Start is called before the first frame updat
   

    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")) {
            Debug.Log("Iv'e pressed Left Mouse Button");
            if(heldItem != null){
                Debug.Log(heldItem);
                Debug.Log("Dannys Sexy 8----D");
                heldItem.Use();
            } else {
                Debug.Log("We arent holding anything (X)");
            }
        }

        if(Input.GetButton("Fire2")){
            if(heldItem != null){
                heldItem.SecondaryUse();
            } else {
                Debug.Log("We are not holding anything! (Z)");
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            if (heldItem != null) {
                heldItem.Drop();
                heldItem = null;
            } else {
                Debug.Log("We definently arent holding anything");
            }
        }
    }
    [SerializeField]
    Transform hand; 

   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key")){
            totalKeys += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Door")){
            if(totalKeys > 0){
                totalKeys -= 1;
                Destroy(other.gameObject);
                aud.PlayOneShot(doorOpen);
            } else {
                Debug.Log("You need a key to open this door!");
            }
        }
        
        Debug.Log("I have hit " + other.gameObject.name + "!");

        if(heldItem == null){
            if(other.gameObject.CompareTag("Item")){
                heldItem = other.GetComponent<IItem>();
                heldItem.Pickup(hand);
            }
        } else {
            Debug.Log("You already have an item!!");
        }

        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins += 1;
        }

        if (other.gameObject.CompareTag("Floor")) {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

}