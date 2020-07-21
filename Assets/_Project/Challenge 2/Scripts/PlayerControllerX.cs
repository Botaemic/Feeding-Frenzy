using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    [SerializeField] private float _spawnRate = 1f;

    private float _timer = 0f;
    void Update()
    {
        if (LevelManager.Instance.IsGameRunning)
        {
            _timer -= Time.deltaTime;

            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space) && _timer < Mathf.Epsilon)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                _timer = _spawnRate;
            }
        }
    }
}
