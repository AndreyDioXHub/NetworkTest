using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AtackProvider : MonoBehaviour
{
    public static AtackProvider Instance;

    [SerializeField]
    private List<Health> _enemies = new List<Health>();
    [SerializeField]
    private List<Atack> _players = new List<Atack>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        foreach(var player in _players)
        {
            foreach(var enemy in _enemies)
            {
                float distance = Vector3.Distance(player.Trans.position, enemy.Trans.position);

                if (player.MayAtack(distance, enemy.netId.ToString()))
                {
                    enemy.SetDamage(player.Damage, out bool isKilled);

                    if (isKilled)
                    {

                    }
                }
            }
        }
    }

    public void RegisterPlayer(Atack player)
    {
        _players.Add(player);
    }

    public void RegisterEnemy(Health enemy)
    {
        _enemies.Add(enemy);
    }
}
