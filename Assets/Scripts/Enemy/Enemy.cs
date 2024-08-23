using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInstance", menuName = "New Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    [SerializeField]
    public string EnemyName;
    [SerializeField]
    public GameObject Prefab;
    [SerializeField]
    public float Health;
    [Tooltip("Количество экземпляров")]
    public int InstanceAmount = 10;
}
