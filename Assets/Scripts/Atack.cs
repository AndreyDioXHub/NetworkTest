using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UniRx;
using System;
using Mirror;

public class Atack : NetworkBehaviour
{
    public Transform Trans => _transform;
    public float Damage { get => _damage; set { _damage = value; UpdateDamage(); } }
    public float Radius { get => _radius; set { _radius = value; UpdateRadius(); } }

    [SerializeField]
    private Transform _transform;

    [SerializeField, SyncVar]
    private float _damage;
    [SerializeField, SyncVar]
    private float _radius;

    [SerializeField, SyncVar]
    private int _atackSlotsCount = 2;

    public IntReactiveProperty ReactiveEnemyCounter;

    private Dictionary<string, bool> _atackSlots = new Dictionary<string, bool>();


    void Start()
    {

    }

    void Update()
    {
        
    }

    public bool MayAtack(float distance, string name)
    {
        bool result = false;

        if(_radius >= distance)
        {
            if (_atackSlots.TryGetValue(name, out result))
            {
                _atackSlots[name] = true;
                result = true;
            }
            else
            {
                if(_atackSlots.Count < _atackSlotsCount)
                {
                    _atackSlots.Add(name, true);
                    result = true;
                }
            }
        }
        else
        {
            if (_atackSlots.TryGetValue(name, out result))
            {
                _atackSlots.Remove(name);
            }
        }

        return result;
    }

    public void UpdateDamage()
    {
    }

    public void UpdateRadius()
    {
    }

    public override void OnStartLocalPlayer()
    {
        _damage = Model.Instance.Damage.Value;
        _radius = Model.Instance.Radius.Value;

        Model.Instance.Damage.Subscribe(_ => { Damage = _; });
        Model.Instance.Radius.Subscribe(_ => { Radius = _; });
    }

    public override void OnStartServer()
    {
        AtackProvider.Instance.RegisterPlayer(this);
    }
}
