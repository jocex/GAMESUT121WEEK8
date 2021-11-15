using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodScore : MonoBehaviour
{
    CircleCollider2D GoodCircle;
    bool inGood;
   // public AudioClip Ding;
   // AudioSource audioSource;
    
   

   private void Awake(){
        GoodCircle=GetComponent<CircleCollider2D>();
        GoodCircle.isTrigger = true;
       //  audioSource = GetComponent<AudioSource>();
    }

    private void Start(){
       // audioSource = GetComponent<AudioSource>();
    }

      public void OpenGood(){
        gameObject.SetActive(false) ;
         

    }
  
   void Update(){

        if(inGood == true){
              //audioSource.PlayOneShot(Ding,1);
             OpenGood();
             ScoreManager.AddToScore();
         }
        
    }

    

     private void OnTriggerEnter2D(Collider2D other){
        if( other.CompareTag("Player")){
            inGood = true;
             //if(!Ding.isPlaying){
               
              
           // }
            
           
           
        }
    }

   /* private void OnTriggerExit2D(Collider2D other){
        if( other.CompareTag("Player")){
        inGood = false;
        }
    }*/
       
}
