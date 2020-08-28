﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float explosionRadius;

    public LayerMask damageMask;

    public float damage=20;

    public bool isRotate = false;

    
    private void Start()
    {
        Destroy(gameObject, 3.5f);
        if (isRotate)
        {
            GetComponent<Rigidbody>().AddTorque(transform.right * 1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var colliders = Physics.OverlapSphere(transform.position, explosionRadius, damageMask);

        foreach(var collider in colliders)
        {
            var target = collider.GetComponent<PlayerCharacter>();
            if (target)
            {
                target.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}