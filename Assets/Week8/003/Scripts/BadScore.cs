using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadScore : MonoBehaviour
{
    CircleCollider2D BadCircle;
    bool inBad;

    private void Awake(){
        BadCircle=GetComponent<CircleCollider2D>();
        BadCircle.isTrigger = true;
    }

      public void OpenBad(){
        gameObject.SetActive(false) ;
    }
  
   void Update(){
        if(inBad == true){
             OpenBad();
             ScoreManager.MinusToScore();
         }

    }

    

    private void OnTriggerEnter2D(Collider2D other){
        if( other.CompareTag("Player")){
            inBad = true;
            
           
           
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if( other.CompareTag("Player")){
        inBad = false;
        }
    }
}
