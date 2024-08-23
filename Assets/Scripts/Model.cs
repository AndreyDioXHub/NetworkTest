using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class Model : MonoBehaviour
{
    public static Model Instance;

    public FloatReactiveProperty Speed;
    public FloatReactiveProperty Damage;
    public FloatReactiveProperty Radius;

    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _speedStep = 0.5f;

    [SerializeField]
    private float _damage = 10f;
    [SerializeField]
    private float _damageStep = 10f;

    [SerializeField]
    private float _radius = 2f;
    [SerializeField]
    private float _radiusStep = 1;

    private void Awake()
    {
        
        if (Instance == null)
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
        Speed.Value = _speed;
        Damage.Value = _damage;
        Radius.Value = _radius;
    }

    void Update()
    {
        
    }

    public void Upgrade()
    {
        int rand = Random.Range(0, 10);

        if (rand >= 0 && rand < 6)
        {
            _speed += _speedStep;
            Speed.Value = _speed;
        }
        else if(rand >= 6 && rand < 9)
        {
            _damage += _damageStep;
            Damage.Value = _damage;
        }
        else
        {
            _radius += _radiusStep;
            Radius.Value = _radius;
        }
    }
}
