using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnList : ScriptableObject
{
    public List<GameObject> spawnList = new List<GameObject>();


    public GameObject GetRandomSpawn()
    {
        return spawnList.Count > 1 ? spawnList[Random.Range(0, spawnList.Count)] : null;
    }


}
