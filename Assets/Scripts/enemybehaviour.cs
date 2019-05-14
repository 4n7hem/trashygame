﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class enemybehaviour : MonoBehaviour {

	public Transform Target;
	public Rigidbody2D rigidbody;
	public Collider2D damager;
	public Health health;

	public float speed;
	public float gravity = 9.8f;
	public float attackTimer = 0;
	public float attackCooldown = 1.33f;

	public float distance;
	public float huntDistance;
	public bool _running;
	public bool _attacking;
	public bool movable;

	private float vx;
	private float vy;
	private bool facingRight;
	private float oldPosition = 0.0f;
	private Vector3 normalScale;
	private Vector3 invertedScale;

	private Animator animator;

	void Start() {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		oldPosition = transform.position.x;
		normalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
		invertedScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		health = GetComponent<Health>();
	}

	void Update() {
		//always checking the hp
		if (health.health <= 0){
			movable = false;
			_attacking = false;
			_running = false;
		}		
		//if it should move
        if(movable == false){
            _running = false;
            if(_attacking == false){
                _attacking = true;
				attackTimer = attackCooldown;				
            }
            else if (Vector3.Distance(transform.position, Target.position) > distance) {
                movable = true;                
            }
        }
		//how it moves
        if ((Vector3.Distance(Target.position, transform.position) < huntDistance) && movable == true) {
			_running = true;			
			damager.enabled = false;
            _attacking = false;	
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);			
			if (Vector3.Distance(transform.position, Target.position) <= distance) {
				_running = false;
                movable = false;				     
			}
		}
		//how the hitbox waits between each attack
		if(_attacking == true){
			if(attackTimer <= 0){
				attackTimer = attackCooldown;
			}
			else if (attackTimer > 0){
				attackTimer -= Time.deltaTime;
				if(attackTimer <= attackCooldown - 0.2f && attackTimer > attackCooldown - 0.8f){
					damager.enabled = true;					
				}
				else {
					damager.enabled = false;
				}												
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
	}
	
	
	public void ChangeDirection(){
		if (facingRight == false){
			transform.localScale = invertedScale;
		}
		if (facingRight == true){
			transform.localScale = normalScale;
		} 
	}
}
