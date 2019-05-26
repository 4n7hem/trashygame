using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    public GameObject animation1;
    public GameObject animation2;
    public int levelIndex;

    void SwitchAnimations(){
        animation1.active = false;
        animation2.active = true;
    }

    void TurnOnAnimations(){
        animation2.active = true;
    }

    void LoadMenu(){
        SceneManager.LoadScene(levelIndex);
    }
}
