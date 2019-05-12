using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBehaviour : MonoBehaviour{

    public GameObject target;
    public Collider2D hitbox;

    public float lifeTime = 1f;
    public float passedTime = 0f;

    // Start is called before the first frame update
    void Start(){        
    target = GameObject.FindGameObjectWithTag("Player");
    hitbox = GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update(){
        passedTime += Time.deltaTime;
        if(lifeTime <= passedTime){
            Destroy(this.gameObject);
        }        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
           
        }
    }
}
