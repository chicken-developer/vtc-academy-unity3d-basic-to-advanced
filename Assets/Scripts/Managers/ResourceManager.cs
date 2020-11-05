using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ResourceManager {
    //Singleton:
    private ResourceManager() {
        
    }
    public static ResourceManager Instance { get { return Nested.instance; } }
    private class Nested {
        static Nested() {
        }
        internal static readonly ResourceManager instance = new ResourceManager();
    }
    
    //All ResourceManager Value
    private List<GameObject> _resourceList;
    
    //All ResourceManager Behaviors
    public List<GameObject> LoadSceneResource(String sceneName) {
        //TODO: May be not use
        return new List<GameObject>();
    }

    public GameObject LoadPrefab(String prefabLink, GameObject needFill = null) {
         needFill = UnityEngine.Object.Instantiate(Resources.Load(prefabLink, typeof(GameObject))) as GameObject;
         return needFill;
    }
    
}
