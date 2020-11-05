using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private Scene _defaultScene;
    private Scene _currentScene;
    private Queue<Scene> _scenes;
    void Awake() {
        _defaultScene = new Scene();
        _currentScene = _defaultScene;
    }
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
