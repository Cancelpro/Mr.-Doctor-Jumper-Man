using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    Camera mainCam;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float smoothTurn = 0.1f;
    float turnSmoothVelocity;
    [SerializeField] float gravity = 5.0f;
    [SerializeField] float jumpHeight = 0;
    private bool isJumping = false;
    private float currentJump = 0;
    void Start(){
        charController = GetComponent<CharacterController>();
        mainCam = Camera.main;
    }

    void Update(){
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        //Debug.Log("jo");
        Vector3 charGravity = Vector3.zero;
        if (moveDir.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + mainCam.transform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            charController.Move(direction.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded.instance.isGrounded){
            isJumping = true;
        }

        if (isJumping && currentJump <= jumpHeight){
            currentJump++;
            charGravity.y = currentJump;
            charController.Move(charGravity * Time.deltaTime);

        } else{
            isJumping = false;
            currentJump = 0;
            charGravity.y -= gravity; //borrowing from https://answers.unity.com/questions/574328/jumping-with-a-character-controller.html
            charController.Move(charGravity * Time.deltaTime);
        }

    }


}
