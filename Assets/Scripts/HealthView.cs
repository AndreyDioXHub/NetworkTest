using CodeMonkey.HealthSystemCM;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthView : NetworkBehaviour
{
    [SerializeField]
    private HealthBarUI _healthBarUI;
    private Health _healthModel;
    private HealthSystem _healthSystem;
    private float _hTransfer { get; set; } = 0;



    private void UpdateView(float hTransfer) {
        Debug.Log($"Update health to {hTransfer}");
        _healthSystem.SetHealth(hTransfer);
    }

    public override void OnStartClient() {
        base.OnStartClient();
        _healthModel = gameObject.GetComponent<Health>();
        _hTransfer = _healthModel.HealthMax;
        _healthSystem = new HealthSystem(_hTransfer);
        _healthBarUI.SetHealthSystem(_healthSystem);
        _healthModel.HealthProperty.Subscribe(h => { _hTransfer = h; UpdateView(_hTransfer); });
    }
}
