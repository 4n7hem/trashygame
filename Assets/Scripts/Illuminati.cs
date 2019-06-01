using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illuminati : MonoBehaviour{
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            #if UNITY_EDITOR
			    UnityEditor.EditorApplication.isPlaying = false;
		    #else
			    Application.Quit();
		    #endif
        }        
    }
}
