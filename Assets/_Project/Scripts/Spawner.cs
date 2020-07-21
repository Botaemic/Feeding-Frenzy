using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnList _spawnList = null;
    [SerializeField] private float _spawnTimer = 2f;
    [SerializeField] private SpawnPoint[] _spawnPoints = null;

    private float _timer = 0f;
    private int counter = 0;

    void Start()
    {
        _timer = _spawnTimer;    
    }

    void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            _timer -= Time.deltaTime;
            if (_timer <= Mathf.Epsilon)
            {
                var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                var location = spawnPoint.GetSpawnPoint();

                var spawn = _spawnList.GetRandomSpawn();
                if (spawn == null) { return; }
                
                counter++;
                if (counter % 10 == 0)
                {
                    _spawnTimer -= 0.2f;
                    _spawnTimer = Mathf.Clamp(_spawnTimer, 0.5f, 2f);
                }
                _timer = _spawnTimer;

                Instantiate(spawn, location, spawnPoint.gameObject.transform.rotation);
            }
        }
    }
}
