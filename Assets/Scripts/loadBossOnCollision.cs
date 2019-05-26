using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBossOnCollision : MonoBehaviour
{
    public CameraSeguePersonagem cameraS;
    public Camera camera;
    public Transform cameraT;
    public Transform cameraArray;
    public GameObject healthBar;
    public GameObject boss;
    public GameObject wall1;
    public GameObject wall2;    
    public GameObject music1;
    public GameObject music2;
    public GameObject victory;    
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update(){        
        if(boss == null){
            victory.active = false;
            wall1.active = false;
            wall2.active = false;
            cameraS.enabled = true;
            music1.active = true;
            music2.active = false;
            this.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        cameraS.enabled = false;
        cameraT.transform.position = cameraArray.position;
        healthBar.active = true;
        wall1.active = true;
        wall2.active = true;
        boss.active = true;
        music1.active = false;
        music2.active = true;

    }
}
