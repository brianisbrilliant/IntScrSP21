using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int oxygenSupply = 0;
    bool crouch = false;
    public int coins = 0;

    [SerializeField]
    Transform hand;

    IItem heldItem;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Is fire one working???");
            if(heldItem != null)
            {
                heldItem.Use();
            } else 
            {
                Debug.Log("We aren't holding anything.");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(heldItem != null)
            {
                heldItem.Drop();
                heldItem = null;
            } else 
            {
                Debug.Log("We aren't holding anything");
            }
        }

        //crouching();
    }

    void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("I have hit " + other.gameObject.name);

        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("I'm trying to pick up an item.");
            if(heldItem != null)
            {
                return;
            }
            heldItem = other.GetComponent<IItem>();
            heldItem.Pickup(hand);
        }

        if(other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            oxygenSupply++;
        }
        
        Debug.Log("I have hit" + other.gameObject.name);

        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins += 1;
            // Destroy the coin
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    void OntriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;

        }

        void crouching()
        {
            if (Input.GetKeyDown(KeyCode.C) && crouch == false)
            {
                transform.localScale = new Vector3(1, .5f, 1);
                crouch = true;
            }
            else if (Input.GetKeyDown(KeyCode.C) && crouch == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                crouch = false;
            }
        }
    }
}
