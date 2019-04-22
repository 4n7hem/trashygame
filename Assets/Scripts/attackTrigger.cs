using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    public int loss = 1;

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Breakable"){
            coll.SendMessageUpwards("Damage", loss);
        }
    }
}
