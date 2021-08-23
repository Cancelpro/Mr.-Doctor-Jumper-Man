using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBehaviour : MonoBehaviour
{
    [SerializeField] Transform walker;
    private float turnValue = 0;


    private void OnTriggerExit(Collider col){
        turnValue+= 180.0f;
        Vector3 TurnAround = new Vector3(0, turnValue, 0);
        walker.rotation = Quaternion.Euler(TurnAround);

        Debug.Log("dafuq");
    }
}
