using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public bool isInputOn  = true;
    

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        if(isInputOn == true){
			Vector2 move = Vector2.zero;

			move.x = Input.GetAxis ("Horizontal");

			if (Input.GetButtonDown ("Jump") && grounded) {
				velocity.y = jumpTakeOffSpeed;
			} else if (Input.GetButtonUp ("Jump")) 
			{
				if (velocity.y > 0) {
					velocity.y = velocity.y * 0.5f;
				}
			}

			if(move.x > 0.01f)
			{
				if (this.transform.localScale.x < 0) {
					this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				}
			} 
			else if (move.x < -0.01f)
			{
				if (this.transform.localScale.x > 0) {
					this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
				}
			}

			animator.SetBool ("grounded", grounded);
			animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

			targetVelocity = move * maxSpeed;
		}
    
    }
    
}