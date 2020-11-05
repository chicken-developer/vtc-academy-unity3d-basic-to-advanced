using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController: MonoBehaviour {
    private float _position;
    private float _rotation;
    public void MoveForward() {
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(position.x + 0.1f, position.y, position.z);
        transform1.position = position;
    }

    public void MoveBackward() {
        
    }

    public void MoveLeft() {
        
    }

    public void MoveRight() {
        
    }

    public void Jump() {
        
    }

     public void Crunch() {
        
    }
    
    public void Lie() {
        
    }

    void Awake() {
        
    }
}