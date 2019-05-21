﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loadSceneOnCollision : MonoBehaviour {
	
	public GameObject completeMenuUI;
	public Animator animator;	
	public int levelAccess;	
	private bool isInputOn = true;
	private float startTime;

    
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			isInputOn = false;
			completeMenuUI.SetActive(true);
			Time.timeScale = 0f; 
		}
	}

	public void LoadLevel() {
		Time.timeScale = 1f;		
		animator.SetTrigger("Fade Out");		
	}
	public void OnFadeComplete(){
		SceneManager.LoadScene(levelAccess);
	}	
}
