using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private PlatformEffector2D platEffector;
    public float startWait;
    private float totalWait;

    void Start()
    {
        platEffector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
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

    IEnumerator RestartPlatform()
    {
        yield return new WaitForSeconds(0.1f);
        platEffector.rotationalOffset = 0;
    }
}
