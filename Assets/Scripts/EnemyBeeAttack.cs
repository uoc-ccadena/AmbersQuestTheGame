using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeAttack : MonoBehaviour
{
    public Animator animBeeAttack;
    public float raycastDistance = 0.5f;
    private float waitAttack = 1.5f;
    private float nextAttack;

public GameObject beeBullet;

    void Start()
    {
        nextAttack = 0;
    }

    void Update()
    {
        nextAttack -=Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.down, Color.red, raycastDistance);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);

        if (hit2D.collider!=null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (nextAttack<0)
                {
                    Invoke("FireBullet",0.5f);
                    animBeeAttack.Play("EnemyAttack");
                    nextAttack = waitAttack;
                }
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet;

        bullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
