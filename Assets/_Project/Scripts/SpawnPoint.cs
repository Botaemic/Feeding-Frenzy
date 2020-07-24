using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _range = 1f;
   

    [Header("Debug range view")]
    [SerializeField] private float _debugRange = 20f;
    [SerializeField] private Color _gizmosColor = Color.white;
    
    public Vector3 GetSpawnPoint()
    {
        Vector3 pos = transform.position + (Random.Range(-_range, _range) * Vector3.right);
        return pos;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.matrix = transform.localToWorldMatrix;
        //Gizmos.DrawWireCube(transform.position + ((transform.forward * _debugRange) /2), Vector3.one + (_directionRange * _range*2) + (transform.forward * _debugRange));

        Vector3 size = new Vector3( _range * 2, 0, 0);
        Vector3 debugSize = new Vector3(0, 0, _debugRange);
        Debug.Log(size);
        Debug.Log(debugSize);
        Debug.Log("Total size:" + (size + debugSize));
        Gizmos.DrawWireCube(Vector3.zero + (debugSize/2), (size + debugSize));
    }
}
