using Mirror;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class Health : NetworkBehaviour
{
    public Transform Trans => _transform;

    public UnityEvent OnDiedOnServer = new UnityEvent();

    [SerializeField]
    private Transform _transform;
    [SerializeField, SyncVar]
    private float _health = 100;

    public float HealthMax => _health;

    [SerializeField, SyncVar(hook = nameof(UpdateHealth))]
    private float _healthCur;

    public ReactiveProperty<float> HealthProperty = new ReactiveProperty<float>();

    [SerializeField]
    private float _time = 1, _timeCur;

    void Start()
    {
        ResetHealt();
    }

    public void Init(float maxHealth) {
        _health = maxHealth;
        ResetHealt();
    }

    public void SetDamage(float damage, out bool isKilled)
    {
        isKilled = false;

        _timeCur += Time.deltaTime;

        if(_timeCur > _time)
        {
            Debug.Log(damage);

            _healthCur -= damage;
            _healthCur = _healthCur <= 0 ? 0 : _healthCur;
            
           

            if (_healthCur == 0)
            {
                isKilled = true;
                Death();
            }

            _timeCur = 0;
        }
    }

    public void ResetHealt()
    {
        _healthCur = _health;
        HealthProperty.Value = _health;
    }


    public void Death()
    {
        Debug.Log("is dead");

        if (isServer)
        {
            OnDiedOnServer?.Invoke();
        }
        else
        {

        }
    }

    private void UpdateHealth(float oldHealth, float newHealth) {
        HealthProperty.Value = newHealth;
    }

    public override void OnStartServer()
    {
        AtackProvider.Instance.RegisterEnemy(this);
    }
}
