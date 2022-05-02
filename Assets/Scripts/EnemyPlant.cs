using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant : MonoBehaviour
{
    private float waitIdle;
    public float waitAttack = 3;
    public Animator animPlant;
    public GameObject bulletPrefab;
    public Transform launchPoint;

    private void Start()
    {
        waitIdle = waitAttack;
    }

    private void Update()
    {
        if (waitIdle<=0)
        {
            waitIdle = waitAttack;
            animPlant.Play("AttackPlant");
            Invoke("Bullet", 0.5f);
        }
        else
        {
            waitIdle -= Time.deltaTime;
        }
    }

    public void Bullet()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, launchPoint.position, launchPoint.rotation);
    }
}
