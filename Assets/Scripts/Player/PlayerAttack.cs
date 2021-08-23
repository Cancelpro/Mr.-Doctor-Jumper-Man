using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{



    private void OnTriggerEnter(Collider col){
        if(col.gameObject.layer == 9){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("LOAD THE SCENE");
        }
        Debug.Log(col.gameObject.layer);
    }
}
