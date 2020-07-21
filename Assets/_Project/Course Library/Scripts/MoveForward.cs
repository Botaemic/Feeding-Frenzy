using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
