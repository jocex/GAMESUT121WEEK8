using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodScore : MonoBehaviour
{
    CircleCollider2D GoodCircle;
    bool inGood;
   

    private void Awake(){
        GoodCircle=GetComponent<CircleCollider2D>();
        GoodCircle.isTrigger = true;
    }

      public void OpenGood(){
        gameObject.SetActive(false) ;
         

    }
  
   void Update(){

        if(inGood == true){
             OpenGood();
             ScoreManager.AddToScore();
         }
        
    }

    

    private void OnTriggerEnter2D(Collider2D other){
        if( other.CompareTag("Player")){
            inGood = true;
            
           
           
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if( other.CompareTag("Player")){
        inGood = false;
        }
    }
       
}
