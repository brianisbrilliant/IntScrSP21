    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        public NavMeshAgent agent;
        public Transform goal;
        public GameObject player;

        //public LookForPlayer eye;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();

            //Debug.Log("Distance to player: " + Vector3.Distance(this.transform.position, goal.transform.position));

            //if player is close 
            //point a raycast at the player to see if player is visible
            //is the ai facing the player?
            //if all three conditions are true, agent.destination = goal.position
            //destroy navmesh agent
            //destroy patrol script
            //add component rigidbody

            //if the player gets far away(double the activation distance) start patroling again

        }
    }