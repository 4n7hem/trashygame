using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGate : MonoBehaviour
{
    public loadSceneOnCollision scene;
    public InteractionExit intEx;
    public LoadSceneOnClick click;

    public void callCompletion(){
        if(scene != null){
            scene.OnFadeComplete();
        }
        if(intEx != null){
            intEx.OnFadeComplete();
        }
        if(click != null){
            click.OnFadeComplete();
        }
    }  

}
