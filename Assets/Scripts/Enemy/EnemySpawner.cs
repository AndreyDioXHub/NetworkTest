using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    List<Enemy> _enemies;
    // Start is called before the first frame update

    public override void OnStartServer() 
    {

        base.OnStartServer();

        foreach (Enemy enemy in _enemies) 
        {
            for (int i = 0; i < enemy.InstanceAmount; i++) 
            {
                GameObject enemyItem = Instantiate(enemy.Prefab);
                NetworkServer.Spawn(enemyItem);
                enemyItem.GetComponent<Health>().Init(enemy.Health);
                enemyItem.GetComponent<EnemyRespawner>().Respawn();                
            }
        }
    }
}
