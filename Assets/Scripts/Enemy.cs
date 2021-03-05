using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int health {get; set;}

    void Start() {
        health = Random.Range(8,16);
    }

    public void TakeDamage(int amount) {
        health -= amount;

        Debug.Log("I am taking Damage! Health: " + health);
        if(health <= 0) {
            Destroy(this.gameObject, 5);
            Destroy(this);  // destroys the Enemy component
            this.gameObject.AddComponent<Rigidbody>();
        }
    }
}
