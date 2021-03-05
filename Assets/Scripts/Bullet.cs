using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damageAmount = 2;

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("IDamageable")) {
            Debug.Log("I am attempting to damage something.");
            col.gameObject.GetComponent<IDamageable>().TakeDamage(damageAmount);
        }

        Destroy(this.gameObject);
    }
}
