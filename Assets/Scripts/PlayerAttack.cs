using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour {
	public Collider2D col;
	private bool _attacking = false;	
	private bool attacking {
		get {return _attacking;}
		set {
			_attacking = value;
			if (anim != null) anim.SetBool("Attacking", attacking); 
		}
	}

	[SerializeField]
	private float attackTimer = 0;
	[SerializeField]
	private float attackCooldown = 0.2f;
	private Animator anim;
	public AudioSource slash;

	void Awake() {
		anim = gameObject.GetComponent<Animator>();
	}

	void FixedUpdate() {
		if (attacking){
			this.EnablingCollider();						
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
			}
		} else if (Input.GetKeyDown("x")) {
			attacking = true;
			slash.Play();
			attackTimer = attackCooldown;
		}		
	}
	public void EnablingCollider(){
		if(attacking == true){
			col.enabled = true;
		}
		else{	
		col.enabled = false;
		}
	}
}
