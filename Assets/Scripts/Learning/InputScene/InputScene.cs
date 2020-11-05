using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using Debug = UnityEngine.Debug;

public class Bullet {
    //Init bullet here
    public TextAsset textFile = Resources.Load<TextAsset>("Prefabs/InputScenePrefabs/debugFile");
    public GameObject bullet = UnityEngine.Object.Instantiate(Resources.Load("Prefabs/InputScenePrefabs/cube", typeof(GameObject))) as GameObject;
    public Material bulletMaterial = Material.Instantiate(Resources.Load("Prefabs/Materials/cubeMaterial", typeof(Material))) as Material;
    public void reset() {
        
    }
}
public class BulletPool {
    //Create singleton for bullet pool
    private BulletPool() { }
    private static BulletPool instance = null;
    public static BulletPool Instance {
        get {
            if (instance == null)
                instance = new BulletPool();
            return instance;
        }
    }
    private static int poolCapacity = 3;
    private Queue<Bullet> _bullets = new Queue<Bullet>(poolCapacity);
    public Bullet GetBullet() {
        switch (_bullets.Count) {
            case 0:
                //Need change queue capacity
                return new Bullet();
            default: return _bullets.Dequeue();
        } 
    }
    
    public void ReturnBullet(Bullet bullet) {
        bullet.reset();
        _bullets.Enqueue(bullet);
    }
}

public class InputScene : MonoBehaviour {
    /* All init object  */
    private Button btn_ChangeImage;
    private int fireRange = 100;
    private float bulletSpeed = 0.01f;
    private Button btn_Fire;
    private GameObject gun;
    private GameObject player;
    
     /***************************************************************************************************/
    /****All handle define function */
   
    void HandlePlayerMovement(GameObject myPlayer) {
        var oldPosition = player.transform.position;
        float movementSpeed = 0.2f;
        //Go to forward
        if (Input.GetKey(KeyCode.W)) {
            myPlayer.transform.position = new Vector3(oldPosition.x ,
                                                      oldPosition.y,
                                                   oldPosition.z + 1 * movementSpeed);}
        //Go to left
        if (Input.GetKey(KeyCode.A)) {
            myPlayer.transform.position = new Vector3(oldPosition.x - 1 * movementSpeed,
                                                         oldPosition.y,
                                                         oldPosition.z);}
        //Go to backward
        if (Input.GetKey(KeyCode.S)) {
            myPlayer.transform.position = new Vector3(oldPosition.x,
                                                      oldPosition.y,
                                                   oldPosition.z - 1 * movementSpeed);}
        //Go to right
        if (Input.GetKey(KeyCode.D)) {
            myPlayer.transform.position = new Vector3(oldPosition.x + 1 * movementSpeed,
                                                         oldPosition.y,
                                                         oldPosition.z);}
        //Jump
        if (Input.GetKey(KeyCode.Space)) {
            //Jump func here
        }
    }
    void HandlePlayerInput(GameObject myPlayer) {
        //Rotation
        var oldRotation = player.transform.rotation;
        if (Input.GetKey(KeyCode.Q) ) {
            player.transform.rotation = new Quaternion(oldRotation.x , oldRotation.y + 0.001f, oldRotation.z , oldRotation.w);
        }
        if (Input.GetKey(KeyCode.E) ) {
            player.transform.rotation = new Quaternion(oldRotation.x , oldRotation.y - 0.001f, oldRotation.z , oldRotation.w);
        }
    }

    Material RandomColorMaterial() {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Shader shader = cube.GetComponent<Shader>();
        Texture texture = gun.GetComponent<Texture>();
        Color color = Color.blue;

        var material = new Material(shader);
        material.mainTexture = texture;
        material.color = color;
        return material;
    }
    /****End handle define function */
    /***************************************************************************************************/
    private void Awake() {
        btn_ChangeImage = GameObject.Find("InputScene/UIs/Canvas/btn_ChangeImage").GetComponent<Button>();
        var title = btn_ChangeImage.GetComponentInChildren<Text>();
        title.text = "Change Color";
        btn_Fire = GameObject.Find("InputScene/UIs/Canvas/btn_Fire").GetComponent<Button>();
        gun = GameObject.Find("InputScene/Player/gun");
        btn_Fire.GetComponentInChildren<Text>().text = "Fire( A)";
        player = GameObject.Find("InputScene/Player");
    }

    private void OnEnable() {
        //Fire Btn
        btn_Fire.onClick.AddListener(() => {
            //Get Gun position
            Bullet bulletObject = BulletPool.Instance.GetBullet();
            bulletObject.bullet.transform.position = new Vector3( gun.transform.position.x ,
                                                                gun.transform.position.y ,
                                                                gun.transform.position.z + 3);
            //bulletObject.bullet.GetComponent<Renderer>().material = bulletObject.bulletMaterial;
            //bulletObject.bullet.GetComponent<MeshRenderer>().material = RandomColorMaterial();

        });
    }
    
    void Update() {
        HandlePlayerMovement(player);
        HandlePlayerInput(player);
    }

}
