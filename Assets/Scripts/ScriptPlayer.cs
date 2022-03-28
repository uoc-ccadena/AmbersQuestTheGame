using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    Rigidbody2D rigidAmber;
    public float velocidadMax;
    Animator animAmber;

    bool canMove = true;

    //Jumping vars
    bool inFloor = false;
    float checkFloorRadius = 0.2f;
    public LayerMask floorLayer;
    public Transform checkFloor;
    public float jumpPower;

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
     if (canMove && inFloor && Input.GetAxis("Jump") > 0){
         animAmber.SetBool("inFloor", false);
         rigidAmber.velocity = new Vector2(rigidAmber.velocity.x, 0f);
         rigidAmber.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
         inFloor = false;
     }

     inFloor = Physics2D.OverlapCircle(checkFloor.position, checkFloorRadius, floorLayer);
     animAmber.SetBool("inFloor", inFloor);

     float move = Input.GetAxis("Horizontal");

     if (canMove){
        if(move > 0 && !turnAmber){
            MakeTurn();
        } else if (move < 0 && turnAmber){
            MakeTurn();
        }
        
        rigidAmber.velocity = new Vector2(move * velocidadMax, rigidAmber.velocity.y);

        //Make Amber Run
        animAmber.SetFloat("VelMov", Mathf.Abs(move));
     }else{
        rigidAmber.velocity = new Vector2(0, rigidAmber.velocity.y);
        animAmber.SetFloat("VelMov", 0);
     }   

    }

    void MakeTurn(){
        turnAmber = !turnAmber;
        renderAmber.flipX = !renderAmber.flipX;    
    }

    public void changeStateCanMove(){
        canMove = !canMove;
    }
}
