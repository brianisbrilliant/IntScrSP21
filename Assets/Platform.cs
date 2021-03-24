using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FallingPlatform2 : MonoBehaviour
{

    [SerializeField]
    float hangTime = 2f, resetTime = 4f, returnInterval = 1f; 


    //private variables
    Rigidbody rb; 
    Vector3 startPostition; 
    Renderer rend; 

    Quaternion startRotation;

    Color startColor; 
    bool platformIsActive = false; 

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    Color activecolor = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); 
        rb.isKinematic = true; //freeze the platfomr 
        startPostition = this.transform.position;  //set the initial postion of the platform 
        startRotation = this.transform.rotation;
        rend = this.GetComponent<Renderer>(); // get the compment 
        startColor = rend.material.color; //get the start color so after we change the color we can change it back 



    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")&& !platformIsActive) {
            StartCoroutine(Fall());   
        }
    }
    IEnumerator Fall() { 
        Debug.Log("Starting to fall. Man its a long way down!"); 
        rend.material.color = Color.red;
        yield return new WaitForSeconds(hangTime); 
        rb.isKinematic = false;

        yield return new WaitForSeconds(resetTime); 
        Debug.Log("Resseting platform."); 
        StartCoroutine(ReturnToStart());
         rb.isKinematic = true;
        rend.material.color = startColor; 
    }
    IEnumerator ReturnToStart() { 
         Vector3 endPosition = this.transform.position; 
         Quaternion endRotation = this.transform.rotation; 
         float elapsedTime = 0f; 
         while(elapsedTime < returnInterval) { 
             this.transform.position = Vector3.Lerp(endPosition, startPostition, curve.Evaluate(elapsedTime / returnInterval)); 
             this.transform.rotation = Quaternion.Lerp(endRotation, startRotation, curve.Evaluate(elapsedTime / returnInterval));
             elapsedTime += Time.deltaTime; 

             yield return null; 

         }
         this.transform.position = startPostition; 
         rend.material.color = startColor; 
         platformIsActive = false;
    }

    IEnumerator LerpColor(Color startColor, Color endColor, float interval) {
        float elapsedTime = 0f; 
        while(elapsedTime < interval) {
            rend.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(elapsedTime / interval)); 
            elapsedTime += Time.deltaTime; 
            yield return null; 
            
        }
    } 
}