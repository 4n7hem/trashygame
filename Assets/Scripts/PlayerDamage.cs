using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public Rigidbody2D rigid;
    public Transform trans;
    public Transform enemyTrans;   
    public Vector2 normalVelocity;   

    public float power = 300f;
    public bool knockback;
    public float knockbackDuration = 0.3f;
    private float knockTimer = 0;  
    
    // Start is called before the first frame update
    void Start(){
    rigid = GetComponent<Rigidbody2D>();
    trans = GetComponent<Transform>(); 
    normalVelocity = rigid.velocity;   
    knockback = false;    
    }

    // Update is called once per frame
    void FixedUpdate(){             
        if(knockback == true){
            knockTimer += Time.deltaTime;
            if(knockTimer >= knockbackDuration){
                rigid.velocity = normalVelocity;
                knockTimer = 0;
                knockback = false;
            }
            else{    
                if((trans.position.x-enemyTrans.position.x)<=0){        
                    rigid.velocity = new Vector2(-power, rigid.velocity.y);
                }
                else{
                    rigid.velocity = new Vector2(power, rigid.velocity.y);
                }
            }                    
        }        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy Attack")){        
            knockback = true;
            enemyTrans = other.GetComponent<Transform>();
        }            
    }
}
