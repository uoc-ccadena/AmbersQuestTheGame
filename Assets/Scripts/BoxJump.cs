using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
    public Animator animBox;
    public SpriteRenderer spriteBox;
    public GameObject partsBox;
    public GameObject colliderBox;
    public Collider2D col2D;
    public float jumpForce = 2;
    public int hits=1;
    public GameObject hiddenFruit;

    private void Start()
    {
        hiddenFruit.SetActive(false);
        hiddenFruit.transform.SetParent(FindObjectOfType<ObjectsManager>().transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up*jumpForce;
            HitBox();
        }
    }

    public void HitBox()
    {
        hits--;
        animBox.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if (hits<=0)
        {
            hiddenFruit.SetActive(true);
            colliderBox.SetActive(false);
            col2D.enabled=false;
            partsBox.SetActive(true);
            spriteBox.enabled=false;
            Invoke("DestroyBox",0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
