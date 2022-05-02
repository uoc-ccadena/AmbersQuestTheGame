using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Animator animAmber;
    private float checkPointX, checkPointY;
    public GameObject[] totalHearts;
    private int life;
    
    void Start()
    {
        life = totalHearts.Length;

        if (PlayerPrefs.GetFloat("checkPointX")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointX"),PlayerPrefs.GetFloat("checkPointY")));
        }
    }

    private void Hearts()
    {
        if (life < 1)
        {
            Destroy(totalHearts[0].gameObject);
            animAmber.Play("DeadAnimation");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Invoke("RestartGame", 0.8f);
        }
        else if (life < 2)
        {
            Destroy(totalHearts[1].gameObject);
            animAmber.Play("DeadAnimation");
        }
        else if (life < 3)
        {
            Destroy(totalHearts[2].gameObject);
            animAmber.Play("DeadAnimation");
        }
    }

    public void CheckPointActive(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointX",x);
        PlayerPrefs.SetFloat("checkPointY",y);
    }

    public void PlayerDead()
    {
        life--;
        Hearts();
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
