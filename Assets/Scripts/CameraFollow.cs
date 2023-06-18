using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    private Vector3 desiredPosition;

    //private Vector3 desiredPosition;
    void Start()
    {
         gameOver = false;
    }

 

    // Update is called once per frame
    void Update()
    {
       if (!gameOver && target != null)
        {
            FollowTarget();
        }
    }
     private void FollowTarget()
    {
        desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpRate * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
   
  
}
