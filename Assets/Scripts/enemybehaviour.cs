using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class enemybehaviour : MonoBehaviour{

    public Transform Target;
    public Rigidbody2D rigidbody;

    public float speed;
    public float gravity = 9.8f;
    public int distance;
    public float huntDistance;
    private float vx;
    private float vy;
    private bool facingRight;

    private Animator animator;

    void Start (){
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        vx = rigidbody.velocity.y;

        if((Vector3.Distance(Target.position, transform.position) < huntDistance)){
            if(Vector3.Distance(transform.position, Target.position) > distance){
                transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            }
        }
        if(vx > 0.01f){
            if(transform.localScale.x < 0){
                this.ChangeDirection();
            }
        }
        if(vx < -0.01f){
            if(transform.localScale.x > 0){
                this.ChangeDirection();
            }
        }
    }
    public void ChangeDirection(){
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); 
    }
}
