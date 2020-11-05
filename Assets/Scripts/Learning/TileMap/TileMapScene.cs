using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapScene : MonoBehaviour
{
    private SpriteRenderer player;
    private SpriteRenderer skill_01, skill_02, skill_03;
    
    void HandleUsingSkill(){
         if(skill_01 != null){
            if(Input.GetKeyDown(KeyCode.Alpha1) ){
                Debug.Log("Click skill 1");
                skill_01.transform.localScale =  new Vector3(0.8f, 0.8f, 0.8f);
            }
            if(Input.GetKeyUp(KeyCode.Alpha1) ){
                Debug.Log("Release skill 1");
                skill_01.transform.localScale =  new Vector3(0.6f, 0.6f, 0.6f);
            }
         } 
         else {
            Debug.Log("Not found skill 1 btn");
         }
         if(skill_02 != null){
            if(Input.GetKeyDown(KeyCode.Alpha2) ){
                Debug.Log("Click skill 2");
                skill_02.transform.localScale =  new Vector3(0.8f, 0.8f, 0.8f);
            }
            if(Input.GetKeyUp(KeyCode.Alpha2) ){
                Debug.Log("Release skill 2");
                skill_02.transform.localScale =  new Vector3(0.6f, 0.6f, 0.6f);
            }
         } else {
            Debug.Log("Not found skill 2 btn");
         }

         if(skill_03 != null){
            if(Input.GetKeyDown(KeyCode.Alpha3) ){
                Debug.Log("Click skill 3");
                skill_03.transform.localScale =  new Vector3(0.8f, 0.8f, 0.8f);
            }
            if(Input.GetKeyUp(KeyCode.Alpha3) ){
                Debug.Log("Release skill 3");
                skill_03.transform.localScale =  new Vector3(0.6f, 0.6f, 0.6f);
            }
         } else {
            Debug.Log("Not found skill 3 btn");
         }
    }
    void HandleMovement(){
        if(player != null){    
            if (Input.GetKey( KeyCode.W)) {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,2,0));     
            }
            if (Input.GetKey(KeyCode.A)) {
                Debug.Log("Player move left");
                player.transform.position = new Vector3(player.transform.position.x - 0.01f, player.transform.position.y, player.transform.position.z);

            }
            if (Input.GetKey( KeyCode.D)) {
                Debug.Log("Player move right");
                player.transform.position = new Vector3(player.transform.position.x + 0.01f, player.transform.position.y, player.transform.position.z);

            }
        
        } else{
            Debug.Log("Not found player");
        }
    }
    void Awake(){
        player = GameObject.Find("2DGame/Player").GetComponent<SpriteRenderer>();
        skill_01 = GameObject.Find("2DGame/Skill_01").GetComponent<SpriteRenderer>();
        skill_02 = GameObject.Find("2DGame/Skill_02").GetComponent<SpriteRenderer>();
        skill_03 = GameObject.Find("2DGame/Skill_03").GetComponent<SpriteRenderer>();
    }
    void Start(){
        
    }

    void Update(){
        HandleMovement();
        HandleUsingSkill();
    }
}
