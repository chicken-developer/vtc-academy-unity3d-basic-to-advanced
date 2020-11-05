using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScene : MonoBehaviour
{
    private GameObject plan;

    void HandlePlayerInput(GameObject plan) {
        var oldRotation = plan.transform.rotation;
        //if (Math.Abs(plan.transform.rotation.x) > 0.15f || Math.Abs(plan.transform.rotation.z) > 0.15f) {
         //   Debug.Log("Current rotation Z: " + oldRotation.z);

      //  }
        if (Input.GetKey(KeyCode.W) && plan.transform.rotation.z < 0.15f) {
            Debug.Log("Current rotation Z: " + plan.transform.rotation.z);
            plan.transform.rotation = new Quaternion(oldRotation.x , oldRotation.y, oldRotation.z + 0.001f, oldRotation.w);
        }
        if (Input.GetKey(KeyCode.S) && plan.transform.rotation.z > -0.15f) {
            Debug.Log("Current rotation Z: " + plan.transform.rotation.z);
            plan.transform.rotation = new Quaternion(oldRotation.x , oldRotation.y , oldRotation.z - 0.001f, oldRotation.w);
        }
        if (Input.GetKey(KeyCode.A) && plan.transform.rotation.x > -0.15f) {
            Debug.Log("Current rotation X: " + plan.transform.rotation.x);
            plan.transform.rotation = new Quaternion(oldRotation.x - 0.001f, oldRotation.y , oldRotation.z, oldRotation.w);
        }
        if (Input.GetKey(KeyCode.D) && plan.transform.rotation.x < 0.15f) {
            Debug.Log("Current rotation X: " +plan.transform.rotation.x);
            plan.transform.rotation = new Quaternion(oldRotation.x + 0.001f, oldRotation.y, oldRotation.z, oldRotation.w );
        }
    }
    private void Awake() {
        plan = GameObject.Find("Plane");
    }

    void Start() {
        
    }

    void Update() {
        HandlePlayerInput(plan);
    }
}
