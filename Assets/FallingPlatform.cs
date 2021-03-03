using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    float hangTime = 2f, resetTime = 4f, returnInterval = 1f;

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    Color activeColor = Color.red;

    Rigidbody rb;
    Renderer rend;

    Vector3 startingPosition;
    Quaternion startingRotation;
    Color startingColor;
    bool platformIsActive = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        rend = GetComponent<Renderer>();
        startingColor = rend.material.color;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && !platformIsActive) {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall() {
        Debug.Log("Starting Fall()");
        platformIsActive = true;
        StartCoroutine(LerpColor(startingColor, activeColor, .2f));
        yield return new WaitForSeconds(hangTime);
        Debug.Log("HangTime is complete.");
        rb.isKinematic = false;
    
        yield return new WaitForSeconds(resetTime);
        Debug.Log("reset timer is complete.");
        rb.isKinematic = true;
        //transform.position = startingPosition;
        StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart() {
        Debug.Log("Starting returnToStart()");
        Vector3 endPosition = transform.position;
        Quaternion endRotation = transform.rotation;
        float elapsedTime = 0f;
        while(elapsedTime < returnInterval) {
            transform.position = Vector3.Lerp(endPosition, startingPosition, curve.Evaluate(elapsedTime / returnInterval));
            transform.rotation = Quaternion.Lerp(endRotation, startingRotation, elapsedTime / returnInterval);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = startingPosition;
        transform.rotation = startingRotation;
        StartCoroutine(LerpColor(activeColor, startingColor, 1));
        platformIsActive = false;
        Debug.Log("ending returnToStart()");
    }

    IEnumerator LerpColor(Color startColor, Color endColor, float t) {
        float elapsedTime = 0f;
        while(elapsedTime < 1f) {
            rend.material.color = Color.Lerp(startColor, endColor, curve.Evaluate(elapsedTime / t));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        rend.material.color = endColor;
    }
}
