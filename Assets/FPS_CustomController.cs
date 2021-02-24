using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CustomController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    Transform hand;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have it " + other.gameObject.name + "!");

        if(other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.SetParent(hand);
            other.transform.localPosition = Vector3.zero;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
