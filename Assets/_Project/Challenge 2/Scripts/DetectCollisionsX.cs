using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Dog dog = other.GetComponent<Dog>();
        if (dog)
        {
            EventManager.Instance.OnPointCollected?.Invoke(1);
        }
        else
        {
            EventManager.Instance.OnBallHitGround?.Invoke();
        }
        Destroy(gameObject);
    }
}
