using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("On Collision enter" + other.gameObject.name );
    }

    private void OnCollisionExit(Collision other) {
        Debug.Log("On Collision exit" + other.gameObject.name );

    }

    private void OnTriggerEnter(UnityEngine.Collider other) {
        Debug.Log("On trigger enter" + other.gameObject.name );

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
