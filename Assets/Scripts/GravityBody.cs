using System;
using DefaultNamespace;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    [SerializeField] public Planet attractorPlanet;
    //private Transform playerTransform;
        
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        if (attractorPlanet)
            attractorPlanet.Attract(transform);
    }
}