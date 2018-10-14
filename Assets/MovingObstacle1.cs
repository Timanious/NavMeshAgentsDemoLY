using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingObstacle1 : MonoBehaviour 
{
    public float speed = 1;
    public float moveDistance = 20;
    public enum LerpMethod
    {
        Straight,
        EaseIn,
        EaseOut,
        Exponential,
        SmoothStep,
        SmootherStep
    }
    public LerpMethod lerpMethod;
    
    Vector3 a,b,destination;
    float lerpTime = 1;
    float currentLerpTime;

    void Start()
    {
        a = transform.position;
        b = transform.position + Vector3.forward * moveDistance;
        destination = b;
    }

    void Update()
    {
        Move();
    }
   
    void Move()
    {
        if (Vector3.Distance(transform.position, destination) > 0.05f)
        {
            //increment timer once per frame
            currentLerpTime += Time.deltaTime * speed;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float t = currentLerpTime / lerpTime;

            switch (lerpMethod)
            {
                case LerpMethod.Straight:
                    break;
                case LerpMethod.EaseIn:
                    t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
                    break;
                case LerpMethod.EaseOut:
                    t = Mathf.Sin(t * Mathf.PI * 0.5f);
                    break;
                case LerpMethod.Exponential:
                    t = t * t;
                    break;
                case LerpMethod.SmoothStep:
                    t = t * t * (3f - 2f * t);
                    break;
                case LerpMethod.SmootherStep:
                    t = t * t * t * (t * (6f * t - 15f) + 10f);
                    break;
            }
            transform.position = destination == b ? Vector3.Lerp(a, b, t) : Vector3.Lerp(b, a, t);
        }
        else
        {
            currentLerpTime = 0f;
            destination = destination == b ? a : b;
        }
    }
}
