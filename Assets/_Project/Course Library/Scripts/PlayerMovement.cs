using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xRange = 15f;
    [SerializeField] private float _zRange = 15f;

    [SerializeField] private Transform _projectileSpawnLocation = null;

    [SerializeField] private Food[] _projectiles = null;
    [SerializeField] private GameObject _foodIcon = null;

    private int _foodIndex = 0;
    // Update is called once per frame

    private void Start()
    {
        _foodIcon.GetComponent<Image>().sprite = _projectiles[_foodIndex].Icon;
    }


    void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            var direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

            transform.Translate(direction * _speed * Time.deltaTime);

            ClampHorizontalPosition();
            ClampVerticalPosition();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_projectiles[_foodIndex], _projectileSpawnLocation.position, Quaternion.identity);
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                _foodIndex = ++_foodIndex % _projectiles.Length;
                _foodIcon.GetComponent<Image>().sprite = _projectiles[_foodIndex].Icon;
            }

        }
    }

    #region Private
    private void ClampVerticalPosition()
    {
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > _zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _zRange);
        }
    }

    private void ClampHorizontalPosition()
    {
        if (transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Animal animal = collision.gameObject.GetComponent<Animal>();
        if (animal)
        {
            EventManager.Instance.OnPlayerHit?.Invoke(1);
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
