using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageEnemy : MonoBehaviour
{
    public Collider2D enemyCollider;
    public Animator enemyAnimator;
    public SpriteRenderer enemyRenderer;
    public GameObject destroyParticle;
    public float jumpBounce = 2.5f;
    public int lifes = 2;
    public AudioSource killEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*jumpBounce);
            LoseLifeHit();
            CheckLife();
        }
    }

    public void LoseLifeHit()
    {
        lifes--;
        enemyAnimator.Play("EnemyHit");
    }

    public void CheckLife()
    {
        if(lifes==0)
        {
            destroyParticle.SetActive(true);
            enemyRenderer.enabled = false;
            killEnemy.Play();
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
                Destroy(gameObject);
    }
}
