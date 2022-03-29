using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public static bool isFloor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFloor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isFloor = false;
    }
}
