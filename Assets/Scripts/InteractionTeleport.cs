using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class InteractionTeleport : MonoBehaviour{

    public enum TriggerType {Enter, Exit};
    
    [SerializeField]
    private GameObject arrowSprite;
    [SerializeField]
    private GameObject zSprite;
 
    [Tooltip ("The Transform to teleport to")]
    [SerializeField] 
    private Transform teleport;
          
    [Tooltip ("Trigger Event to Teleport")] //no clue of what this does
    [SerializeField] 
    TriggerType type;
    void Start(){
    }
    void Update(){    
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            arrowSprite.SetActive(true);
            zSprite.SetActive(true);
            if(Input.GetKeyDown("z")){
                other.transform.position = teleport.position;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other){
        arrowSprite.SetActive(false);
        zSprite.SetActive(false);
    }
}
