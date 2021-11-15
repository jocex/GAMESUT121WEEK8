using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public CapsuleCollider2D cc; 
    public GameObject teleportPortal;
    public string nextScene;
    
   
  
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if( other.CompareTag("Player")){
            SceneManager.LoadScene(nextScene);
            
           
           
        }
    }
}
