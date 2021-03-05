using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int oxygenSupply = 0;
    public int coins = 0;

    public TextMeshProUGUI scoreText;

    [SerializeField]
    Transform hand;     // this is a hand-positioned Empty child of Camera.
    
    [SerializeField]
    AudioClip doorOpen, getKey;

    AudioSource aud;

    IItem heldItem;

    Vector3 startPosition;
    
    int totalKeys = 0;

    bool crouch = false;


    void Start() {
        startPosition = this.transform.position;
        // allow FPSController to "teleport"
        this.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        aud = this.GetComponent<AudioSource>();
    }

    float timer = 0, interval = 2;

    // Update is called once per frame
    void Update()
    {
        // a test timer
        if(timer < interval) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
            Debug.Log("Timer has gone off!");
        }


        if(Input.GetButton("Fire1")) {
            Debug.Log("I've pressed Left Mouse Button");
            if(heldItem != null) {
                heldItem.Use();
            } else {
                Debug.Log("We aren't holding anything.");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            if(heldItem != null) {
                heldItem.Drop();
                heldItem = null;
            } else {
                Debug.Log("We aren't holding anything.");
            }
        }

        if(this.transform.position.y < -5) {
            Debug.Log("Resetting Position");
            this.transform.position = startPosition;
        }

        crouching();
    }

    

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("I have hit " + other.gameObject.name + "!");

        if(other.gameObject.CompareTag("Key")) {
            totalKeys += 1;
            Destroy(other.gameObject);
            aud.PlayOneShot(getKey);
        }

        if(other.gameObject.CompareTag("Door")) {
            if(totalKeys > 0) {
                totalKeys -= 1;
                Destroy(other.gameObject);
                aud.PlayOneShot(doorOpen);
            } else {
                Debug.Log("You need a key to open this door.");
            }
        }

        if(other.gameObject.CompareTag("Item")) {
            Debug.Log("I'm trying to pick up an item.");
            if(heldItem != null) {
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
        
        if(other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            coins += 1;
            scoreText.text = "Keys: " + coins.ToString();
            
            // Destroy the coin
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Floor")) {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;

        }
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
