using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of the bullets fired from the guns
/// </summary>
public class Bullet : MonoBehaviour
{
    #region Properties
    /// <summary> The bullet's speed <summary>
    [SerializeField] private float _bulletSpeed = 20f;

    /// <summary> The bullet's lifetime before being destroyed <summary>
    [SerializeField] private float _lifeTime = 10f;

    /// <summary> An instance of the rigidbody <summary>
    private Rigidbody rb;

    #endregion

    #region Start
    /// <summary>
    /// Makes the bullet move and destroys it after it's lifetime
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * _bulletSpeed;

        Destroy(gameObject, _lifeTime);
    }

    #endregion
}
