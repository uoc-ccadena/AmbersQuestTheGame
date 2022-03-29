using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    Rigidbody2D rigidAmber;
    public float velocidadMax=2; 
    Animator animAmber;

    //Jumping vars
    public float jumpPower=2;
    public bool improvedJump=false; 
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    SpriteRenderer renderAmber;

    void Start()
    {
     rigidAmber = GetComponent<Rigidbody2D>(); 
     renderAmber = GetComponent<SpriteRenderer>();
     animAmber = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right")){
            rigidAmber.velocity = new Vector2(velocidadMax,rigidAmber.velocity.y);
            renderAmber.flipX = false;
            animAmber.SetBool("isRunning", true);
        } else
        if (Input.GetKey("a") || Input.GetKey("left")){
            rigidAmber.velocity = new Vector2(-velocidadMax,rigidAmber.velocity.y);
            renderAmber.flipX = true;
            animAmber.SetBool("isRunning", true);
        } else {
            rigidAmber.velocity = new Vector2(0, rigidAmber.velocity.y);
            animAmber.SetBool("isRunning", false);
        }
        if (Input.GetKey("space") && CheckFloor.isFloor){
            rigidAmber.velocity = new Vector2(rigidAmber.velocity.x, jumpPower);
        }
        if (CheckFloor.isFloor==false)
        {
            animAmber.SetBool("isJumping", true);
            animAmber.SetBool("isRunning", false);
        }
        if (CheckFloor.isFloor==true)
        {
            animAmber.SetBool("isJumping", false);
        }
        if (improvedJump){
            if (rigidAmber.velocity.y<0){
                rigidAmber.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rigidAmber.velocity.y>0 && !Input.GetKey("space")){
                rigidAmber.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
