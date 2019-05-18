using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour{

    public float speed = 0;
	public float rotatingSpeed= 0;
	public GameObject target; 

    public float lifeTime = 9f;
    public float passedTime = 0;  

	public Rigidbody2D rb;

	// Use this for initialization
	void Start(){	
		target = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody2D>();        
	}
	
	// Update is called once per frame
    void Update(){
        passedTime += Time.deltaTime;
        if (passedTime >= lifeTime){
            Destroy (this.gameObject);
        }
    }
	void FixedUpdate (){	
		Vector3 point2Target = transform.position - target.transform.position;
		point2Target.Normalize ();
		float value = Vector3.Cross (point2Target, transform.right).z;

        //how it spins
		rb.angularVelocity = rotatingSpeed * value;
		rb.velocity = transform.right * speed;       
	}    

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Boss" && other.tag != "Enemy Attack" && other.tag != "Background" && other.tag != "Enemy Spell") {
			Destroy (this.gameObject, 0.02f);

		}
	}
}