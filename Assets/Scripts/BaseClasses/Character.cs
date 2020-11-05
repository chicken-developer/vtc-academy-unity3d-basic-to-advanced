using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour  {
    
    private float _moveSpeed;
    private float _jumpForce;

    void Movement() {
        float movementSpeed = 0.01f;
        if (Input.GetKey(KeyCode.W)) {
            transform.position+= Vector3.forward * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * movementSpeed;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.back * movementSpeed;
        }
        
        if (Input.GetKey(KeyCode.Space)) {
        }

        if (Input.GetKey(KeyCode.C)) {
        }

        if (Input.GetKey(KeyCode.Z)) {
        }
    }
    void Awake() {
        
    }

    void Start() {
        
    }

    void Update() {
        Movement();
    }
}