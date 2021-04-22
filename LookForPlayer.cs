using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : MonoBehaviour
{
    public Transform player;
    public bool canSeePlayer;
    public float fieldofView = 60;
    public GameObject patroller;

    RaycastHit hit;

    void Update()
    {
        Vector3 rayDirection = player.position - this.transform.position;
        float angle = Vector3.Angle(rayDirection, transform.forward);

        if(angle < fieldofView) canSeePlayer = true;

        Debug.DrawRay(this.transform.position, transform.forward * 5);
        //Debug.DrawRay(this.transform.position, rayDirection, angle < fieldofView ? Color.green : Color.red);
        Debug.Log("Angle to player: " + angle);

        
        if(physics.RaycastHit(transform.forward, rayDirection, out hit)){
            if(hit.collider.CompareTag("Player")){
                canSeePlayer = true;
            } else {
                canSeePlayer = false;
            }
        }


        if(canSeePlayer){
            float playerPos;
            playerPos = Vector3.Distance(this.transform.position, player.transform.position);
        
            if(playerPos <= 10){
                patroller.GetComponent<Patrol>().agent.destination = player.transform.position;
            }
        }

        

    }
    
}

