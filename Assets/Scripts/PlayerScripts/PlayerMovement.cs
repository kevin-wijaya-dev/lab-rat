using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Rigidbody body;
    Transform groundCheck;
    float groundDistance = 0.1f;

    [SerializeField]bool isGrounded;
    bool isMoving;

    Vector3 lastPosition = new Vector3(0,0,0);

    private void Start() {
        body = GetComponent<Rigidbody>();
        isMoving = false;
        isGrounded = true;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(!GlobalManager.isPaused){
            HandleMovement();
            HandleJumping();
            CheckIfGrounded();
            if(isGrounded){
                HandleAnimation();
            }
        }
    }

    void HandleMovement(){
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += -transform.right * _speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += -transform.forward * _speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += transform.right * _speed * Time.deltaTime;
        }
    }

    void HandleJumping(){
        if(Input.GetKey(KeyCode.Space) && isGrounded){
            body.velocity = new Vector3(body.velocity.x,0,body.velocity.z);
            body.AddForce(new Vector3(0,7,0),ForceMode.Impulse);
        }
    }

    void CheckIfGrounded(){
        if(Physics.Raycast(transform.position,Vector3.down,1.1f,groundMask)){
            isGrounded = true;
        }else{
            isGrounded = false;
        }
    }

    void HandleAnimation(){
        if(lastPosition != transform.position){
            isMoving = true;
        }else{
            isMoving = false;
        }
    }
}
