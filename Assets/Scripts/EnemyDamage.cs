using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour{

    public Rigidbody2D rigid;
    public Animator anim;
    public Transform trans;
    public Transform enemyTrans; 
    public Vector2 normalVelocity;

    public float power = 3f;
    public bool knockback;
    public bool damaged;
    public float knockbackDuration = 0.3f;
    private float knockTimer = 0;  

    // Start is called before the first frame update
    void Start(){
        rigid = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>(); 
        normalVelocity = rigid.velocity;   
        knockback = false;
        damaged = false;        
    }

    // Update is called once per frame
    void FixedUpdate(){        
        if(knockback == true){
            if(enemyTrans == null){
                enemyTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            }
            knockTimer += Time.deltaTime;
            if(knockTimer >= knockbackDuration){
                rigid.velocity = normalVelocity;
                knockTimer = 0;
                knockback = false;
                damaged = false;
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
        if(other.CompareTag("Player Attack")){        
            knockback = true;
            damaged = true;            
            enemyTrans = other.GetComponent<Transform>();
        }
    }    
}
