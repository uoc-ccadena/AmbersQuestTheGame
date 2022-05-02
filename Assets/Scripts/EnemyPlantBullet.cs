using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBullet : MonoBehaviour
{
    public float bulletSpeed = 2;
    public float timeDestroy = 1;
    public bool left;

    private void Start()
    {
        Destroy(gameObject,timeDestroy);
    }

    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left*bulletSpeed*Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right*bulletSpeed*Time.deltaTime);
        }
    }
}
