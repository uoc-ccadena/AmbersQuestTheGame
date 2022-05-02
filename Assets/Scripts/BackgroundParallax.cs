using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private Transform camTransform;
    private Vector3 prevCamPos;
    [SerializeField] private float parallaxCoef;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        prevCamPos = camTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float posX = (camTransform.position.x - prevCamPos.x) * parallaxCoef;
        transform.Translate(new Vector3(posX, 0, 0));
        prevCamPos = camTransform.position;
    }
}
