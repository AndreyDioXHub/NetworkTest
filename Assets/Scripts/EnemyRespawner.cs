using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Respawn()
    {
        int x = Random.Range(-20, 20);
        int z = Random.Range(-20, 20);

        transform.position = new Vector3(x, 1.5f, z);

    }
}
