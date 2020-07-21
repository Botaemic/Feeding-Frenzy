using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    [SerializeField] private float _maximumSpawnInterval = 5f;
    [SerializeField] private float _minimumSpawnInterval = 2f;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    private float _timer = 0f;

    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        _timer = startDelay;
    }


    private void Update()
    {
        if (LevelManager.Instance.IsGameRunning)
        {
            _timer -= Time.deltaTime;
            if (_timer < Mathf.Epsilon)
            {
                _timer = Random.Range(_minimumSpawnInterval, _maximumSpawnInterval);
                SpawnRandomBall();
            }
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        var spawnObject = ballPrefabs[Random.Range(0, ballPrefabs.Length)];
        // instantiate ball at random spawn location
        //Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[0].transform.rotation);
        Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation);
    }

}
