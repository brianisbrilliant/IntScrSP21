using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBox : MonoBehaviour
{
    public float timeT = 0;
    public float xAngle, yAngle, zAngle;
    private GameObject cube1, cube2, cube3, cube4, cube5, cube6;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I exist!");
         FirstIn();
         SecondIn();
           
    }

    // Update is called once per frame
    void Update()
    {
       xAngle = 0.0f;
       yAngle = 5f;
       zAngle = 0.0f;
        cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
       
         cube2.transform.Rotate(xAngle, yAngle - 2.5f, zAngle, Space.World);
         if (timeT < 30)
         {
             timeT += Time.deltaTime;
              for(float i = 0; i <timeT ; i++)
         {
             cube3.GetComponent<Renderer>().material.color = Random.ColorHSV();
              if (i < 5)
         {
             cube2.GetComponent<Renderer>().material.color = Color.green;
             cube6.transform.Rotate(xAngle, yAngle - 2.5f, zAngle, Space.World);

         } 
         else if (i > 5 && i < 10)
         {
              cube4.transform.Rotate(xAngle, yAngle - 2.5f, zAngle, Space.World);
              cube6.GetComponent<Renderer>().material.color = Random.ColorHSV();
         }
         else if(i > 10 && i < 15)
         {
             cube5.transform.Rotate(xAngle, yAngle - 2.5f, zAngle, Space.World);
             cube6.GetComponent<Renderer>().material.color = Random.ColorHSV();
             cube4.GetComponent<Renderer>().material.color = Random.ColorHSV();
         }
         else if(i >= 15 && i < 30)
         {
             cube3.transform.Rotate(xAngle, yAngle - 2.5f, zAngle, Space.World);
             cube6.GetComponent<Renderer>().material.color = Random.ColorHSV();
             cube4.GetComponent<Renderer>().material.color = Random.ColorHSV();
             cube5.GetComponent<Renderer>().material.color = Random.ColorHSV();
         }
         else if (i > 30)
         {
             Destroy(cube3);
             Destroy(cube4);
             Destroy(cube5);
             Destroy(cube6);
         }
         }
         }
         else
         {
             timeT = 0;
         }
         cube2.transform.RotateAround(cube1.transform.position, Vector3.up, 12 * Time.deltaTime);        
         cube6.transform.Translate(0, 0,  Time.deltaTime, Space.World);
         cube3.transform.RotateAround(cube1.transform.position, Vector3.up, 12 * Time.deltaTime);
         cube4.transform.RotateAround(cube1.transform.position, Vector3.up, 12 * Time.deltaTime);
         cube5.transform.RotateAround(cube1.transform.position, Vector3.up, 12 * Time.deltaTime);
         cube6.transform.RotateAround(cube1.transform.position, Vector3.up, 12 * Time.deltaTime);

    }

    void FirstIn()
    {
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 2f, 3f);
        cube1.transform.Rotate(90f, 0.0f, 0.0f, Space.Self);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube1.name = "Self";
    }
    void SecondIn()
    {
            cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube2.transform.position = new Vector3(-3f, 2f, 3f);
            cube2.transform.Rotate(90f, 0.0f, 0.0f, Space.World);
            cube2.name = "World";   
            cube6 = Instantiate(cube2, new Vector3(-3f, 2f, 3f), transform.rotation);
            cube4 = Instantiate(cube2, new Vector3(-3f, 2f, 7f), transform.rotation);
            cube5 = Instantiate(cube2, new Vector3(-3f, 2f, 9f), transform.rotation);
            cube3 = Instantiate(cube2, new Vector3(-3f, 2f, 11f), transform.rotation);
            
    }
    
}
