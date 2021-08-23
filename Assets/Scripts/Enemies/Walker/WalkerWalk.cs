using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerWalk : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = 50f;
    CharacterController chara;
    // Update is called once per frame

    void Start(){
        chara = GetComponent<CharacterController>();

    }
    void Update()
    {
        Vector3 gravityVec = Vector3.zero;
        gravityVec.y -= gravity;
        chara.Move(gravityVec * Time.deltaTime);
        Move();
    }

    void Move(){
        
        chara.Move(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
    }
}
