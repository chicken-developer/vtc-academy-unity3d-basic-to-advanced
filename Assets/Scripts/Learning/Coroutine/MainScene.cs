using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScene : MonoBehaviour {

    private GameObject cube;
    private TextMeshProUGUI textMeshPro;

    IEnumerator Countdown(float countdown, float interval){
        while(countdown > 0){
            textMeshPro.text = "" + countdown;
            yield return new WaitForSeconds(interval);
            countdown--;    
        }
        cube.GetComponent<Rigidbody>().useGravity = true;
        textMeshPro.text = "";
    }
    void Awake() {
        Debug.Log("Enter awake");
        textMeshPro = GameObject.Find("Scene/Canvas/textMeshPro").GetComponent<TextMeshProUGUI>();
        cube = GameObject.Find("Scene/Cube");
    }
    void Start(){
        textMeshPro.text = "Start";
        cube.GetComponent<Rigidbody>().useGravity = false;
        StartCoroutine(Countdown(3f, 1f));
    }
}
