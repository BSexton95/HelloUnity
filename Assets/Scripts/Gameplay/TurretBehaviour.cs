using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField]
    private BulletEmitterBehaviour _gun;
    [SerializeField]
    private float _bulletCoolDown;
    private float _bulletTimer;
    [SerializeField]
    private int _ammo = 0;
    [SerializeField]
    private bool _infiniteAmmo = true;

    public bool CheckHasAmmo()
    {
        if (_infiniteAmmo) return true;

        return _ammo > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckHasAmmo()) return;

        _bulletTimer += Time.deltaTime;

        if (_bulletTimer >= _bulletCoolDown)
        {
            _gun.Fire();
            _bulletTimer = 0;
            
            if (!_infiniteAmmo)
                _ammo--;
        }
    }
}
