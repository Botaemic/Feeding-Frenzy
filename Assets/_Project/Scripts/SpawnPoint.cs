using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _range = 1f;
    [Header("Direction in world space")]
    [SerializeField] private Vector3 _directionRange = Vector3.zero;

    [Header("Debug range view")]
    [SerializeField] private float _debugRange = 20f;
    
    public Vector3 GetSpawnPoint()
    {
        Vector3 pos = transform.position + (Random.Range(-_range, _range) * _directionRange);
        return pos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + ((transform.forward * _debugRange) /2), Vector3.one + (_directionRange * _range*2) + (transform.forward * _debugRange));
    }
}
