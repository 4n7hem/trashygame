using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public Rigidbody2D rigid;
    public Transform player;

    public float power = 0;
    public float duration = 0;   
    
    // Start is called before the first frame update
    void Start()
    {
    rigid = GetComponent<Rigidbody2D>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection){

        float timer = 0;
        while(knockDuration > timer){
            timer += Time.deltaTime;
        }
        rigid.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
        yield return 0;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy Attack")){
            StartCoroutine(Knockback(power, duration, player.transform.position));
        }
    }
}
