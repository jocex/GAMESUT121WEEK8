using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
     public float Horizontal = 0.0f;
     public float Vertical = 0.0f;
    
    float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
          transform.position = new Vector3(-12,-6,0);
    }

    void MoveObject(){
        
       if (Input.GetKey(KeyCode.RightArrow)){
           transform.Translate((Vector2.right *Time.deltaTime)*Horizontal);
       }
       if (Input.GetKey(KeyCode.LeftArrow)){
           transform.Translate((Vector2.left *Time.deltaTime)*Horizontal);
       }
       if (Input.GetKey(KeyCode.DownArrow)){
           transform.Translate((Vector2.down *Time.deltaTime)*Vertical);
       }
       if (Input.GetKey(KeyCode.UpArrow)){
           transform.Translate((Vector2.up *Time.deltaTime)*Vertical);
       }


    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
