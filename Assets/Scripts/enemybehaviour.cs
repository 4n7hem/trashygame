using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class enemybehaviour : MonoBehaviour{

    public Transform Target;

    public float speed;
    public float gravity = 9.8f;
    public int distance;
    public float huntDistance;

    private Animator animator;

    void Start (){
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        if((Vector3.Distance(Target.position, transform.position) < huntDistance)){
            if(Vector3.Distance(transform.position, Target.position) > distance){
                transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            }
        }
    }
}
