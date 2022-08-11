
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private PlayerCar playerCar;
    private ArrowDisplay arrow;
    private Vector2 startPos, endPos;
    private float halfScreen;
    private bool isSwiping;
    private void Start()
    {
        halfScreen = Screen.height / 2;
        playerCar = FindObjectOfType<PlayerCar>();
        arrow = FindObjectOfType<ArrowDisplay>();
    }
    private void Update()
    {
        #if UNITY_EDITOR
        MouseInput();
        #endif

        #if UNITY_ANDROID
        TouchInput();
        #endif
    }

    private void TouchInput()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
        }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            Vector2 currentPos = Input.mousePosition;
            if(currentPos.y >= startPos.y) return;
            Vector2 direction = startPos - currentPos;
            float distance = Vector3.Distance(startPos,currentPos);
            float throwForce =  Mathf.Clamp01(distance/halfScreen);
            DisplayStatistics.Instance.ShowThrowForce(throwForce);
            arrow.ShowDirection(direction, throwForce);
        }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
			endPos = Input.touches[0].position;
            if(endPos.y > startPos.y) return;

		    Vector2	direction = startPos - endPos;

            float distance = Vector3.Distance(startPos,endPos);
            float throwForce =  Mathf.Clamp01(distance/halfScreen);
            playerCar.MoveCar(direction, throwForce);
        } 
    }

    private void MouseInput()
    {
        if(Input.GetMouseButtonDown(0) && !isSwiping)
        {
            isSwiping = true;
            startPos = Input.mousePosition;
          
        }

       if(Input.GetMouseButton(0) && isSwiping)
       {
          Vector2 currentPos = Input.mousePosition;
          if(currentPos.y >= startPos.y) return;
          Vector2 direction = startPos - currentPos;
          float distance = Vector3.Distance(startPos,currentPos);
          float throwForce =  Mathf.Clamp01(distance/halfScreen);
          DisplayStatistics.Instance.ShowThrowForce(throwForce);
          arrow.ShowDirection(direction, throwForce);
       }

       if(Input.GetMouseButtonUp(0) && isSwiping)
        {
            isSwiping = false;
            endPos = Input.mousePosition;
            arrow.DisableArrow();
            if(endPos.y >= startPos.y) return;

            Vector2	direction = startPos - endPos;

            float distance = Vector3.Distance(startPos,endPos);
            float throwForce =  Mathf.Clamp01(distance/halfScreen);
            playerCar.MoveCar(direction, throwForce);
        } 
    }
}
