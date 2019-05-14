using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public Rigidbody2D rigid;
    public Collider2D col;   

    public float power = 3f;
    public bool knockback;  
    
    // Start is called before the first frame update
    void Start(){
    rigid = GetComponent<Rigidbody2D>();
    col = GetComponent<Collider2D>();
    knockback = false;    
    }

    // Update is called once per frame
    void Update(){
        if(knockback == true){
            if(rigid == null){
                return;
            }
            Vector2 velocity = rigid.velocity;
            rigid.AddForce( velocity* power, ForceMode2D.Impulse);            
        }        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Enemy Attack"){        
            knockback = true;
        }            
    }
}
