using System;
using System.Collections;
using System.Collections.Generic;
using BaseClass;
using UnityEngine;

public class Character: MonoBehaviour {
    public CharacterController controller;
    public BaseCharacter character;
    public float movementSpeed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Transform cam;
    void MovementHandle() {
        float horizonntal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizonntal,0,vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angel =
                Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        }
    }

    void InputHandle() {
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("Jump");
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            character.Attack();
        }
    }
    void Awake() {
        character = new BaseCharacter();
    }

    void Start() {
        
    }

    void Update() {
      MovementHandle();
      InputHandle();
    }
}