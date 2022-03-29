using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIABasic : MonoBehaviour
{
public Animator animEnemy;
public SpriteRenderer spriteRenderer;
public float enemySpeed = 0.5f;

private float waitIdle;

public Transform[] movePoints;

public float startWait = 2;

private int i = 0;
private Vector2 actualPosition;

    void Start()
    {
        waitIdle = startWait;   
    }

    void Update()
    {
        StartCoroutine(EnemyFlipMove());

        transform.position=Vector2.MoveTowards(transform.position, movePoints[i].transform.position, enemySpeed*Time.deltaTime);   

        if(Vector2.Distance(transform.position, movePoints[i].transform.position)<0.1f)
        {
            if(waitIdle<=0)
            {
                if(movePoints[i]!=movePoints[movePoints.Length-1])
                {
                    i++;
                }
                else
                {
                    i=0;
                }

                waitIdle = startWait;
            }
            else
            {
                waitIdle -= Time.deltaTime;
            }
        }
    }

    IEnumerator EnemyFlipMove()
    {
        actualPosition=transform.position;
        yield return new WaitForSeconds(0.5f);
        
        if(transform.position.x > actualPosition.x)
        {
            spriteRenderer.flipX = true;
            animEnemy.SetBool("IsIdle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animEnemy.SetBool("IsIdle", false);
        }
        else if (transform.position.x == actualPosition.x)
        {
             animEnemy.SetBool("IsIdle", true);
        }
    }
}
