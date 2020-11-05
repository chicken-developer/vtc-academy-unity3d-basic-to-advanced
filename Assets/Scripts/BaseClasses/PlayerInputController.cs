using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController {
    
    private MovementController _movementController;
    private AnimationController _animationController;
    
    void HandleInputMovement() {
        if (Input.GetKey(KeyCode.W)) {
            _movementController.MoveForward();

        }
        if (Input.GetKey(KeyCode.A)) {
            _movementController.MoveLeft();
        }

        if (Input.GetKey(KeyCode.D)) {
            _movementController.MoveRight();
        }

        if (Input.GetKey(KeyCode.S)) {
            _movementController.MoveBackward();
        }
        
        if (Input.GetKey(KeyCode.Space)) {
            _movementController.Jump();
        }

        if (Input.GetKey(KeyCode.C)) {
            _movementController.Crunch();
        }

        if (Input.GetKey(KeyCode.Z)) {
            _movementController.Lie();
        }
    }

    void HandleInputUsingSkill() {
          
        //Item skills 
        if (Input.GetKey(KeyCode.Alpha1)) {
            
        }

        if (Input.GetKey(KeyCode.Alpha2)) {
            
        }
    }

    void HandleAnotherInput() {
        
    }
    void PlayerInputAwake() {
        _movementController = new MovementController();
    }

    // Update is called once per frame
    void PlayerInputUpdate() {
        HandleInputMovement();
        HandleInputUsingSkill();
        HandleAnotherInput();
    }
}
