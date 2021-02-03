using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public int coin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("I have hit " + other.gameObject.name);

        if (other.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            // Destroy the coin
            Destroy(other.gameObject);
            Debug.Log("I have " + coin + " coins!");
        }
    }
}
