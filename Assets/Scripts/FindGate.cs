using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGate : MonoBehaviour
{
    public loadSceneOnCollision scene;

    public void callCompletion(){
        scene.OnFadeComplete();
    }

}
