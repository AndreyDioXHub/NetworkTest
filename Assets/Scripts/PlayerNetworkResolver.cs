using Fragsurf.Movement;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkResolver : NetworkBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private SurfCharacter _character;
    [SerializeField]
    private Atack _atack;


    void Start()
    {
        
    }

    void Update()
    {

    }
    public override void OnStartClient()
    {

    }

    public override void OnStartLocalPlayer()
    {
        transform.position = Vector3.up * 5;
        _character.enabled = true;
        _atack.enabled = true;
        _camera.SetActive(true);
    }
}
