using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class DinoJumping : MonoBehaviour
{
    private GameObject myDino;
    
    ParticleSystem characterAttackVFX, enemyAttacked, enemyHurt;

    private List<GameObject> gameObjects = new List<GameObject>();
    private float VectorZOriginal;
   
    void HandleInput(GameObject player) {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0,-10,0));

        if (Input.GetKey( KeyCode.W) && player.transform.position.y < 5) {
            Debug.Log("Jump pressed !");
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0,60,0));
            
            player.transform.localScale = new Vector3(1, 1.2f, 1);

        }
        if (Input.GetKey( KeyCode.S)) {
            Debug.Log("Jump pressed !");
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0,-20,0));
            
            //Handle animation
            player.transform.localScale = new Vector3(1, 0.8f, 1);
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    
    }

    void RandomCube() {
        Debug.Log("Current number of cube: " + gameObjects.Count);
        for (int i = 0; i < gameObjects.Count; i++) {
            gameObjects[i].transform.position = new Vector3(
                gameObjects[i].transform.position.x,
                gameObjects[i].transform.position.y,
                gameObjects[i].transform.position.z - 0.05f);

            if (gameObjects[i].transform.position.z < myDino.transform.position.z - 10) {
                gameObjects[i].transform.position = new Vector3(
                        gameObjects[i].transform.position.x,
                        gameObjects[i].transform.position.y, 
                        VectorZOriginal + 10);
            }
        }
        
       
    }
    
    //Particle system
    void HandlePlayerAttack(GameObject player) {
        if (Input.GetKeyUp(KeyCode.Q)) {
            characterAttackVFX.Emit(5);
            enemyAttacked.Emit(5);
            enemyHurt.Play();
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            characterAttackVFX.Stop();
            enemyAttacked.Stop();
            enemyHurt.Stop();
        }
    }
    
    private void Awake() {
        myDino = GameObject.Find("DinoJumping/Dino");
        characterAttackVFX = GameObject.Find("DinoJumping/Dino/fireVFX").GetComponent<ParticleSystem>();
        enemyAttacked = GameObject.Find("DinoJumping/shortCube/attackedVFX").GetComponent<ParticleSystem>();
        enemyHurt = GameObject.Find("DinoJumping/shortCube/hurtVFX").GetComponent<ParticleSystem>();
        characterAttackVFX.Stop();
        enemyAttacked.Stop();
        enemyHurt.Stop();
            
        gameObjects.Add(GameObject.Find("DinoJumping/shortCube"));
        gameObjects.Add(GameObject.Find("DinoJumping/shortCube_2"));
        gameObjects.Add(GameObject.Find("DinoJumping/flyCube"));
        gameObjects.Add(GameObject.Find("DinoJumping/flyCube_2"));
        gameObjects.Add(GameObject.Find("DinoJumping/longCube"));
        gameObjects.Add(GameObject.Find("DinoJumping/longCube_2"));
        VectorZOriginal = gameObjects[0].transform.position.z;
    }

    
    void Start() {
    }
    
    void Update() {
        HandlePlayerAttack(myDino);
        HandleInput(myDino);
        //RandomCube();
    }
}
