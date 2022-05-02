using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeBullet : MonoBehaviour
{
    public float bulletSpeed = 2;
    public float timeDestroy = 2;

    private void Start()
    {
        Destroy(gameObject,timeDestroy);
    }

    private void Update()
    {
            transform.Translate(Vector2.down*bulletSpeed*Time.deltaTime);        
    }
}
