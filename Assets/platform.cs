using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    // y(x,t)=Asin(kx−ωt+ϕ) y ( x , t ) = A sin ( kx − ω t + ϕ )
    // A = amplitude
    // ω = angular frequency
    // k = wave number
    // ϕ = phase in radians
    // y = displacement position in a medium from its equilibrium as a function of both position 
    // x and time t

    public float movementSpeed = 5f;

    public float frequency = 10f;

    public float magnitude = 1f;

    public bool directionRight = true;

    Vector3 pos, localScale;

    void Start()
    {
        pos = transform.position;

        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // get the Input from Horizontal Axis
        // float horizontalInput = Input.GetAxis("Horizontal");

        // get Input from Vertical Axis
        // float verticalInput = Input.GetAxis("Vertical");

        // transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        DirectionToMove ();

        if(directionRight)
        {
            MoveRight();
        } else
        {
            MoveLeft();
        }
        
        
    }

    void DirectionToMove()
    {
        if(pos.x < -7f)
        {
            directionRight = true;
        }
        else if (pos.x > 7f)
        {
            directionRight = false;
        }

        if (((directionRight) && (localScale.x < 0)) || ((!directionRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * movementSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * movementSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Output the Collider's GameObjects name
        Debug.Log(collision.collider.name);
        // DirectionToMove ();

        // if(directionRight)
        // {
        //     MoveRight();
        // } else
        // {
        //     MoveLeft();
        // }

    }
}
