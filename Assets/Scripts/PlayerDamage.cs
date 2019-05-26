using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public Rigidbody2D rigid;
    public Animator anim;
    public Transform trans;
    public Transform enemyTrans;   
    public Vector2 normalVelocity;
    public GameObject audio;   

    public float power = 300f;
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
        anim.SetBool("hurt", damaged);
        if(knockback == true){
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
        if(other.CompareTag("Enemy Attack")){        
            knockback = true;
            damaged = true;
            audio.active = false;
            audio.active = true;
            enemyTrans = other.GetComponent<Transform>();
        }
        else if(other.CompareTag("Enemy Spell")){
            knockback = true;
            damaged = true;
            audio.active = false;
            audio.active = true;
        }            
    }
}
