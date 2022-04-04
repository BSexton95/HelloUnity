using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private string _ownerTag;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _liftTime;
    [SerializeField]
    private bool _destroyOnHit;
    private float _currentLiftTime;
    private Rigidbody _rigidbody;

    public string OwnerTag
    {
        get { return _ownerTag; }
        set { _ownerTag = value; }
    }

    public Rigidbody RigidBody
    {
        get { return _rigidbody; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(OwnerTag))
            return;

        HealthBehaviour otherHealth = other.GetComponent<HealthBehaviour>();

        if (!otherHealth)
            return;

        otherHealth.TakeDamage(_damage);

        if (_destroyOnHit)
            Destroy(gameObject);
    }

    private void Update()
    {
        _currentLiftTime += Time.deltaTime;

        if (_currentLiftTime >= _liftTime)
            Destroy(gameObject);
    }
}
