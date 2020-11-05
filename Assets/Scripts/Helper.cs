using UnityEngine;

public sealed class Helper {
    //Singleton:
    private Helper() {
    }
    public static Helper Instance { get { return Nested.instance; } }
    private class Nested {
        static Nested() {
        }
        internal static readonly Helper instance = new Helper();
    }

    //All Helper methods:
    public GameObject GetChildWithName(GameObject obj, string name) {
        Transform trans = obj.transform;
        Transform childTrans = trans. Find(name);
        if (childTrans != null) {
            return childTrans.gameObject;
        } else {
            return null;
        }
    }
    //Add more methods bellow: 

}
