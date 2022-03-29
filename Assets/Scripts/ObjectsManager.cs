using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsManager : MonoBehaviour
{

    private void Update()
    {
        AllCollected();
    }

    public void AllCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("YOU WON");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
