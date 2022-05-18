using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    private PlatformEffector2D platEffector;
    public float startWait;
    private float totalWait;

    public float platformSpeed = 0.5f;
    private float waitIdle;
    public Transform[] movePoints;
    public float startWaitPlatform = 2;
    private int i = 0;

    void Start()
    {
        platEffector = GetComponent<PlatformEffector2D>();
        waitIdle = startWaitPlatform;  
    }

    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position, movePoints[i].transform.position, platformSpeed*Time.deltaTime);   

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

                waitIdle = startWaitPlatform;
            }
            else
            {
                waitIdle -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            totalWait = startWait;
            StartCoroutine(RestartPlatform());
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (totalWait<=0)
            {
                platEffector.rotationalOffset = 180f;
                totalWait = startWait;
            }
            else
            {
                totalWait -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            platEffector.rotationalOffset = 0;
        }
    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }

    IEnumerator RestartPlatform()
    {
        yield return new WaitForSeconds(0.1f);
        platEffector.rotationalOffset = 0;
    }
}
