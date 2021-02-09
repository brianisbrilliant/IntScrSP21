using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerComponent : MonoBehaviour
{
    public int Coins = 0;
    // Start is called before the first frame update
    public int currScore = 0;

    [SerializeField] Text scoreAmount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("I have hit " + other.gameObject.name);
        if(other.gameObject.CompareTag("Coin"))
        {
            //destroy the coin
            Destroy(other.gameObject);
            Coins += 1;
            currScore = currScore + Coins;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreAmount.text = currScore.ToString("0");
    }
}
