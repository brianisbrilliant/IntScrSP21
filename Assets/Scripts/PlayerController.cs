using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int coins; 
    IItem heldItem;
    // Start is called before the first frame update
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")) {
            Debug.Log("Iv'e pressed Left Mouse Button");
            if(heldItem != null){
                heldItem.Use();
            } else {
                Debug.Log("We arent holding anything");
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            if (heldItem != null) {
                heldItem.Drop();
            } else {
                Debug.Log("We arent holding anything");
            }
        }
    }
    [SerializeField]
    Transform hand; 

   void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have hit " + other.gameObject.name + "!");

        if (other.gameObject.CompareTag("Item"))
        {
            if(heldItem != null){
                return;
            }
            heldItem = other.GetComponent<IItem>();
            heldItem.Pickup(hand);
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
        if (other.gameObject.CompareTag("floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

}