using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectsManager : MonoBehaviour
{
    public Text LevelCompleted;
    public Text totalFruits;
    public Text collectedFruits;
    private int fruitsInLevel;

    private void Start()
    {
        fruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllCollected();
        totalFruits.text = fruitsInLevel.ToString();
        collectedFruits.text = transform.childCount.ToString();
    }

    public void AllCollected()
    {
        if (transform.childCount==0)
        {
            LevelCompleted.gameObject.SetActive(true);
            Invoke("TimerChangeScene",1);
        }
    }

    void TimerChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
