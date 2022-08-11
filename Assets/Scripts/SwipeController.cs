using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    /*
    [SerializeField]
    private int pixelDistToDetect = 10;
    */
    private Vector3 startPos;
    private bool isSwiping;

    private void Update()
    {
        #if UNITY_EDITOR
        TouchInput();
        #endif

        #if UNITY_ANDROID
        MouseInput();
        #endif
    }

    private void TouchInput()
    {
        if(!isSwiping && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            isSwiping = true;
        }

        if(isSwiping)
        {

        }

        if(isSwiping && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) isSwiping = false;
    }

    private void MouseInput()
    {
        if(!isSwiping && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSwiping = true;
        }

        if(isSwiping)
        {

        }

        if(isSwiping && Input.GetMouseButtonUp(0)) isSwiping = false;
    }
}
