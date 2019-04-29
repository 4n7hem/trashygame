using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class enemybehaviour : MonoBehaviour {

	public Transform Target;
	public Rigidbody2D rigidbody;

	public float speed;
	public float gravity = 9.8f;
	public int distance;
	public float huntDistance;
	public bool running;
	public bool attacking;
	private float vx;
	private float vy;
	private bool facingRight;
	private float oldPosition = 0.0f;
	private Vector3 normalScale;

	private Animator animator;

	void Start() {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		oldPosition = transform.position.x;
		normalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void Update() {
		
		// how it moves
		if ((Vector3.Distance(Target.position, transform.position) < huntDistance)) {
			running = true;
			if (Vector3.Distance(transform.position, Target.position) > distance) {
				attacking = true;
				running = false;
				transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
			}
		}
		else{
			running = false;
			attacking = false;
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
         oldPosition = transform.position.x; // update the variable with the new position so we can chack against it next frame
	}
	public void ChangeDirection(){
		if (facingRight == false){
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		if (facingRight == true){
			transform.localScale = normalScale;
		} 
	}
}
