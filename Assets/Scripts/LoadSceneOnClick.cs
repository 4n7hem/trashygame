using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public Animator animator;

	private int level;
	
	public void LoadByIndex(int sceneIndex) {
		level = sceneIndex;
		animator.SetTrigger("Fade Out");
	}
	public void OnFadeComplete(){
		SceneManager.LoadScene(level);
	}
}
