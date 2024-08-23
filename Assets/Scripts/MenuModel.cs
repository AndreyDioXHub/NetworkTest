using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class MenuModel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _speedText;
    [SerializeField]
    private TextMeshProUGUI _damageText;
    [SerializeField]
    private TextMeshProUGUI _radiusText;


    [SerializeField]
    private GameObject _screen;

    public float Speed{ get => _speed; set { _speed = value; UpdateSpeed(); } }
    public float Damage { get => _damage; set { _damage = value; UpdateDamage(); } }
    public float Radius { get => _radius; set { _radius = value; UpdateRadius(); } }

    [SerializeField]
    private Model _model;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _radius;

    public void UpdateSpeed()
    {
        _speedText.text = _speed.ToString();
    }

    public void UpdateDamage()
    {
        _damageText.text = _damage.ToString();
    }

    public void UpdateRadius()
    {
        _radiusText.text = _radius.ToString();
    }

    public void Upgrade()
    {
        _model.Upgrade();
    }

    private void Awake()
    {
        _model.Speed.Subscribe(_ => { Speed = _; });
        _model.Damage.Subscribe(_ => { Damage = _; });
        _model.Radius.Subscribe(_ => { Radius = _; });
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            _screen.SetActive(true);
        }
        else
        {
            _screen.SetActive(false);
        }
    }
}
