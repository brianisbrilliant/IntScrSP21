using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] 
    string nextLevelName = "Sample Scene";

    [SerializeField]
    int nextLevelIndex = -1;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            if(nextLevelIndex >= 0) {                       // if the user has edited the index, use that.
                SceneManager.LoadScene(nextLevelIndex);
            } else {                                        // otherwise use the level name.
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
