using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public Animator animAmber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerDead()
    {
        animAmber.Play("DeadAnimation");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
