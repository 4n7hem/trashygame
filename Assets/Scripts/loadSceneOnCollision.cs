﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loadSceneOnCollision : MonoBehaviour
{
    public GameObject completeMenuUI;
    public string levelAccess = "a";
    private float elapsedTime = 10.0f;
    private bool isInputOn = true;
    private float startTime;
    private float timer;
    
    

     void Start(){         

     }
     void Update(){
         timer += Time.time;
                 
     }
     
     void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            isInputOn = false;
            completeMenuUI.SetActive(true);
            Time.timeScale = 0f;
                        
                 
        }
    }
    public void LoadLevel(){
            SceneManager.LoadScene(levelAccess);
        }
}
