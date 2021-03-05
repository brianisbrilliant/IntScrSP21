using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    Teleporter destination;

    [SerializeField]
    float rechargeInterval = 5f;

    public bool readyToTeleport = true;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player") && readyToTeleport) {
            other.transform.position = destination.transform.position;
            other.transform.Translate(Vector3.up);
            StartCoroutine(Recharge());
        }
    }

    public IEnumerator Recharge() {
        readyToTeleport = false;
        yield return new WaitForSeconds(rechargeInterval);
        readyToTeleport = true;

        // destination.
    }
}
