using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    public int hp = 1;
    public Sprite dmgSprite;

    private SpriteRenderer spriteRenderer;
    void Awake(){

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall (int loss){

        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        if (hp<=0){
            Destroy(gameObject);
        }
    }

 
    
}
