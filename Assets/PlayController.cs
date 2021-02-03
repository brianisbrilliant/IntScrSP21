using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
   public int Coin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        Debug.Log("I have hit " + other.gameObject.name);
        if(other.gameObject.CompareTag("Coin")){
            Coin = +1;
            Destroy(other.gameObject);
        }
    }
}
