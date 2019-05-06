using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadBossOnCollision : MonoBehaviour
{
    public CameraSeguePersonagem cameraS;
    public Camera camera;
    public Transform cameraT;
    public Transform cameraArray;
    public GameObject boss;
    public GameObject wall1;
    public GameObject wall2;
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        cameraS.enabled = false;
        cameraT.transform.position = cameraArray.position;
        wall1.active = true;
        wall2.active = true;
        boss.active = true;

    }
}
