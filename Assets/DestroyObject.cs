using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int objectHealth = 2;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            objectHealth--;

            if (objectHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
