using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractionExit : MonoBehaviour{
    
    public GameObject arrowSprite;    
    public GameObject zSprite;
    public GameObject completeMenuUI;
    public Animator animator;
    public int levelAccess;	
    
    
    void OnTriggerStay2D(Collider2D other){
		if (Input.GetKeyDown("z")){
            if(completeMenuUI != null){
			    completeMenuUI.SetActive(true);
                Time.timeScale = 0f;
            }
            else{
                LoadLevel();
            }			
		}
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            arrowSprite.SetActive(true);
            zSprite.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        arrowSprite.SetActive(false);
        zSprite.SetActive(false);
    }
    public void LoadLevel() {
		Time.timeScale = 1f;		
		animator.SetTrigger("Fade Out");		
	}
	public void OnFadeComplete(){
		SceneManager.LoadScene(levelAccess);
	}	
}
