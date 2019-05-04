using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssalLordBehaviour : MonoBehaviour{
 
	public Transform Target;
	public Rigidbody2D rigidbody;
	public Collider2D damager;

	public float speed;
	public float gravity = 9.8f;
	public int distance;
	public float huntDistance;
	public bool _running;
	public bool _attacking;
	private float vx;
	private float vy;
	private bool facingRight;
	private float oldPosition = 0.0f;
	private Vector3 normalScale;
	private Vector3 invertedScale;
    private bool movable = true;

	private Animator animator;

	void Start() {
		Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		oldPosition = transform.position.x;
		normalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
		invertedScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        _attacking = false;
        _running = false;
	}

	void Update() {
        
        if(movable == false){
            _running = false;
            if(_attacking == false){
                _attacking = true;
            }
            if (Vector3.Distance(transform.position, Target.position) > distance) {
                movable = true;                
            }
        }
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
