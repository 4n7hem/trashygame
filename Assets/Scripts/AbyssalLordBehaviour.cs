﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbyssalLordBehaviour : MonoBehaviour{
 
	public Transform Target;
	public Rigidbody2D rigidbody;
	public Health health;
	public Collider2D damager;
	public GameObject missile;
	public GameObject spike;
	public Slider healthBar;

	public Vector3 array1;
	public Vector3 array2;
	public Vector3 array3;
	public Vector3 array4;
	public Vector3 array5;
	
	public float speed;
	public float gravity = 9.8f;
	public float attackTimer = 0;
	public float attackCooldown = 1.33f;
	public float magicTimer = 0;
	public float magicCooldown = 7.0f;
	public int distance;
	public float huntDistance;
	public bool _running;
	public bool _attacking;
	public bool _casting;
	private bool magicAble;
	private float vx;
	private float vy;
	private bool facingRight;
	private float oldPosition = 0.0f;
	private Vector3 normalScale;
	private Vector3 invertedScale;
    private bool movable = true;
	private System.Random selection = new System.Random();
	

	private Animator animator;

	void Start() {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		health = GetComponent<Health>();
		oldPosition = transform.position.x;
		normalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
		invertedScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);		
        _attacking = false;
        _running = false;
	}

	void Update() {
		//health check
		healthBar.value = health.health;
        //if it should move
        if(movable == false){
            _running = false;
            if(_attacking == false){
                _attacking = true;				
            }
            if (Vector3.Distance(transform.position, Target.position) > distance) {
                movable = true;                
            }
        }
		//how it waits for a cast
		if(magicAble){
			if(magicTimer <= 0){
				magicTimer = magicCooldown;
			}
			else if (magicTimer > 0){
				magicTimer -= Time.deltaTime;
				if(magicTimer <= magicCooldown - 3.0f){
					_casting = true;
				}
				else{
					_casting = false;
				}
			}
		}
		//how it casts magic
		if(_casting == true){
			int random = selection.Next(1,3);
			movable = false;
			if(random == 1 && (magicTimer< magicCooldown - 4.0f && magicTimer > magicCooldown - 4.05f)){
				bool created1 = true;
				if(created1){
					Instantiate(missile, transform.position, transform.rotation);
					created1 = false;
				}	
			}
			else if(random == 2 && (magicTimer< magicCooldown - 4.0f && magicTimer > magicCooldown - 4.05f)){
				bool created1 = true;
				bool created2 = true;
				bool created3 = true;
				bool created4 = true;
				bool created5 = true;
				if(created1){
					Instantiate(spike, array1, transform.rotation);
					created1 = false;
				}
				if(created2){
					Instantiate(spike, array2, transform.rotation);
					created2 = false;
				}
				if(created3){
					Instantiate(spike, array3, transform.rotation);
					created3 = false;
				}
				if(created4){
					Instantiate(spike, array4, transform.rotation);
					created4 = false;
				}
				if(created5){
					Instantiate(spike, array5, transform.rotation);
					created5 = false;
				}	
			}				
		}
		else if(_casting == false){
			
		}
		//how the hitbox waits between each attack
		if(_attacking == true){
			if(attackTimer <= 0){
				attackTimer = attackCooldown;
			}
			else if (attackTimer > 0){
				attackTimer -= Time.deltaTime;
				if(attackTimer <= attackCooldown - 0.66f && attackTimer > attackCooldown - 1.2f && _casting == false){
					damager.enabled = true;					
				}
				else {
					damager.enabled = false;
				}												
			}			
		}
		//how it moves
        if ((Vector3.Distance(Target.position, transform.position) < huntDistance) && movable == true) {
			_running = true;			
			damager.enabled = false;
            _attacking = false;
			magicAble = true;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);			
			if (Vector3.Distance(transform.position, Target.position) <= distance) {
				_running = false;
                movable = false;
				magicAble = false;      
			}
		}		
		if (transform.position.x > oldPosition) // he's looking right
        {
			facingRight = true;
            this.ChangeDirection();
        }
		if (transform.position.x < oldPosition) // he's looking left
        {
			facingRight = false;
            this.ChangeDirection();
        }
		//just in case he's still, so it doesn't keep changing sides
        if(transform.position.x == oldPosition){
            if(facingRight == true){
                transform.localScale = normalScale;
            }
            if(facingRight == false){
                transform.localScale = invertedScale;
            }
        }
         oldPosition = transform.position.x; // update the variable with the new position so we can chack against it next frame
		 animator.SetBool("attacking", _attacking);
		 animator.SetBool("running", _running);
		 animator.SetBool("casting", _casting);
	}
	
	//how it changes the sides
	public void ChangeDirection(){
		if (facingRight == false){
			transform.localScale = invertedScale;
		}
		if (facingRight == true){
			transform.localScale = normalScale;
		} 
	}
}
