using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public Animator animator;

	public int level;
	
	public void LoadByIndex() {		
		animator.SetTrigger("Fade Out");
	}
	public void OnFadeComplete(){
		SceneManager.LoadScene(level);
	}
	public void Reload(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		Time.timeScale = 1f;
	}
}
