using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public Rigidbody2D rigid;   

    public float power = 0f;
    public bool knockback;  
    
    // Start is called before the first frame update
    void Start()
    {
    rigid = GetComponent<Rigidbody2D>();
    knockback = false;    
    }

    // Update is called once per frame
    void Update(){
        if(knockback){
            rigid.AddForce(transform.right * power);
            knockback = !knockback;
        }        
    }
    
    void OnTriggerEnter2D(Collider2D other){        
            knockback = true;        
    }
}
