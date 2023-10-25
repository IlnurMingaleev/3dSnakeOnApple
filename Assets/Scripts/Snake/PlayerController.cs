using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody _rigidbody;
    //[SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private Transform playerMesh;
    [SerializeField] private VariableJoystick _joystick;
 

    [Header("Options")] 
    public readonly float MoveSpeed = 5;

    public readonly float rotationSpeed = 180.0f;

    //cache
    private Vector3 _moveVector;

    private void Awake()
    {
        if (!_rigidbody) _rigidbody = GetComponent<Rigidbody>();
        if (!playerMesh) playerMesh = transform.GetChild(0).transform;

        _moveVector = transform.forward;
    }

    private void Update()
    {
        GatherInput();

        
        
    }

    private void Look()
    {
        if (_moveVector != Vector3.zero)
        {
            var relative = (transform.position + _moveVector) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
    }

    private void GatherInput()
    {
        if (_joystick.Direction.magnitude > 0)
        {
            _moveVector = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
        }
    }
    
    private void FixedUpdate()
    {
        // update movement
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * (MoveSpeed * Time.fixedDeltaTime));
        Look();
        
    }
    
   
}
