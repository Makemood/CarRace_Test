using System.Collections;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 25;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody rb;
    private Transform finish;
    private float raceDistance;
    private Vector3 startPosition;
    private Vector3 lastPosition;

    private  void Start()
    {
        Actions.RestartGame += ResetCar;
        rb = GetComponent<Rigidbody>();
        finish = GameObject.Find("Finish").transform;
        startPosition = transform.position;
        raceDistance = Vector3.Distance(startPosition,finish.position);
        
    }
    private void Update()
    {
        if(transform.position.y < 0)
        {
            transform.position = lastPosition;
        }
    }
    private void OnTriggerEnter()
    {
        Actions.OnFinish();
    }
    private void ResetCar()
    {
        rb.isKinematic = true;
        transform.position = startPosition;
    }
    private IEnumerator CountPassedMap()
    {
        while(true)
        {
            float currentDistance = Vector3.Distance(transform.position,finish.position);
            float passed = raceDistance - currentDistance;
            DisplayStatistics.Instance.ShowPassed(passed/raceDistance);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void MoveCar(Vector2 direction, float throwForce)
    {
        rb.isKinematic = false;
        StopAllCoroutines();
        StartCoroutine(CountPassedMap());
        lastPosition = transform.position;
        Vector3 lookDirection = new Vector3(direction.x , 0, direction.y);
        rb.AddRelativeForce( lookDirection.x * horizontalSpeed, 0, direction.y * verticalSpeed * throwForce);
    }
    
}
