using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translo : MonoBehaviour, IItem
{
    
    [SerializeField]
    Transform FirePoint;

    [SerializeField] GameObject TBullet, player;
    GameObject Bullet;

    [SerializeField] float bulletForce = 10f;



     //bool gunIsFiring = true;
     bool isFire = true;
    
    //this function will be called from the player controller
    void Start() {
        //if(FirePoint == null){
            //FirePoint = this.transform.GetChild(0);
        //}
    }

    public void Pickup(Transform hand) {
        this.gameObject.transform.SetParent(hand);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().enabled = false;
    }

    public void Use() {
        if(isFire)
        {     
            Bullet = Instantiate(TBullet, FirePoint.position, FirePoint.rotation, null);
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
            Debug.Log(TBullet.transform.position);
            isFire = false;
            StartCoroutine(Wait());
            
        }
    }

    public void SecondaryUse(){
        GameObject.FindGameObjectWithTag("Player").transform.position = Bullet.transform.position;
        Destroy(Bullet);
        StartCoroutine(Wait());
    }
    

    public void Drop() {
        Debug.Log("Dropping our item.");
        this.gameObject.transform.SetParent(null);
        this.transform.Translate(0,0,2);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
        this.GetComponent<Collider>().enabled = true;
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(2);
        isFire = true;
    }

    public void Teleport()
    {
        if(TBullet != null){
            player.transform.position = TBullet.transform.position;
            //player.transform.Translate(player.transform.position + Vector3.up);
            Destroy(TBullet);
        }

    }
}