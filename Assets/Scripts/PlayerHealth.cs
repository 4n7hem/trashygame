using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    public int health = 10;
    public bool dead = false;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(health >= 2){
            heart1.SetActive(true);
        }
        else{
            heart1.SetActive(false);
            dead = true;
        }
        if(health >= 4){
            heart2.SetActive(true);
        }
        else{
            heart2.SetActive(false);
        }
        if(health >= 6){
            heart3.SetActive(true);
        }
        else{
            heart3.SetActive(false);
        }
        if(health >= 8){
            heart4.SetActive(true);
        }
        else{
            heart4.SetActive(false);
        }
        if(health >= 10){
            heart5.SetActive(true);
        }
        else{
            heart5.SetActive(false);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy Attack")){                
            health -= 1;
        }
    }
}
