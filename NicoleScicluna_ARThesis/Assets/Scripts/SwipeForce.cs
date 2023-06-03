using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeForce : MonoBehaviour
{
    Vector2 startPos, endPos, direction;

    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField] public float throwForceXandY = 1f;

    [SerializeField] public float throwForceInZ = 50f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;

            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.GetTouch(0).position;

            direction = startPos - endPos;

            rb.isKinematic = false;
            rb.AddForce(- direction.x * throwForceXandY, -direction.y * throwForceXandY, throwForceInZ / timeInterval);
            
            Destroy(gameObject, 3f);
        }
    }
}
