using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyExample : MonoBehaviour
{
    public int totalKeys = 0;
    public Light flashlight;

    bool lightIsOn = false;
    float flIntensity;

    Color doorColor;


    // Start is called before the first frame update
    void Start()
    {
        
        if(flashlight != null) {
            flIntensity = flashlight.intensity;
            flashlight.intensity = 0;
        } else {
            Debug.LogError("There is no flashlight attached.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {              // if you press mouse 1.
            if(lightIsOn) flashlight.intensity = 0;     // if the light is on, turn it off
            else flashlight.intensity = 1;              // if the light is off, turn it on
            lightIsOn = !lightIsOn;                     // flip the boolean
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("I've hit " + other.name);

        if(other.gameObject.CompareTag("Key")) {
            totalKeys += 1;
            Debug.Log("<color=red>totalKeys: " + totalKeys + "</color>");
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Door")) {
            if(totalKeys > 0) {
                totalKeys -= 1;
                Debug.Log("<color=blue>totalKeys: " + totalKeys + "</color>");
                Destroy(other.gameObject);
            } else {
                Debug.Log("You need a key!");
                doorColor = other.GetComponent<Renderer>().material.color;
                other.GetComponent<Renderer>().material.color = Color.red;
            }
            
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Door")) {
            other.GetComponent<Renderer>().material.color = doorColor;
        }
    }
}
