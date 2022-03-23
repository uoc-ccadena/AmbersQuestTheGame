using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    Rigidbody2D rigidAmber;
    public float velocidadMax;
    Animator animAmber;

    //Turn Amber
    bool turnAmber = true;
    SpriteRenderer renderAmber;

    // Start is called before the first frame update
    void Start()
    {
     rigidAmber = GetComponent<Rigidbody2D>();  
     renderAmber = GetComponent<SpriteRenderer>();
     animAmber = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
     float move = Input.GetAxis("Horizontal");
    
     if(move > 0 && !turnAmber){
         MakeTurn();
     } else if (move < 0 && turnAmber){
         MakeTurn();
     }

     rigidAmber.velocity = new Vector2(move * velocidadMax, rigidAmber.velocity.y);  

     //Make Amber Run
     animAmber.SetFloat("VelMov", Mathf.Abs(move));
   
    }

    void MakeTurn(){
        turnAmber = !turnAmber;
        renderAmber.flipX = !renderAmber.flipX;    
    }
}
