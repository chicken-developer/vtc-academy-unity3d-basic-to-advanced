using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    // Start is called before the first frame update
    private UIManager() {
        
    }
    public static UIManager Instance { get { return Nested.instance; } }
    private class Nested {
        static Nested() {
        }
        internal static readonly UIManager instance = new UIManager();
    }
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
