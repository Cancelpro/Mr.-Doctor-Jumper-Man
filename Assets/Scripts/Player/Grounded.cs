using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    // Start is called before the first frame update
    public static Grounded instance;
    public bool isGrounded {get; private set;}
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.layer == LayerMask.GetMask("Ground")){
            isGrounded = true;
            
        }

    }

    private void OnTriggerExit(Collider col){
        if(col.gameObject.layer == LayerMask.GetMask("Ground")){
            isGrounded = false;
        }
    }
}
