using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGhost : MonoBehaviour
{
    public Text Controls;
    public bool showControls=false;

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Controls.gameObject.SetActive(true);
        showControls = true;
    }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Controls.gameObject.SetActive(false);
        showControls = false;
    }
}
