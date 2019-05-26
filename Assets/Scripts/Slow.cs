using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour{

    public PlayerPlatformerController control;    

    // Start is called before the first frame update
    void Start(){
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
    }

    // Update is called once per frame
    public void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            control.maxSpeed = 2;
        }
    }
    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            control.maxSpeed = 7;
        }
    }
}
