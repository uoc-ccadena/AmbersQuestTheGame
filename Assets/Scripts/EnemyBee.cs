using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBee : MonoBehaviour
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
}
