using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //                                                  movement
    private Rigidbody _rb => GetComponent<Rigidbody>();
    private float _forcePower = 30f;
    [SerializeField]
    private float _maxMovementSpeed;
    [SerializeField]
    private VariableJoystick _joystick;

    //                                                  rotation
    [SerializeField]
    private float _rotationSpeed;
    private bool _lockRotation = false;  // for cyclon
    public bool LockRotation
    {
        get
        {
            return _lockRotation;
        }
        set
        {
            _lockRotation = value;
        }
    }
    private void Update()
    {
        Movement();          
    }
    
    private void Movement()
    {
        float movementVertical = _joystick.Vertical;
        float movementHorizontal = _joystick.Horizontal;

        Vector3 movement = new Vector3(movementHorizontal + movementVertical, 0, movementVertical - movementHorizontal);

        if(movementVertical == 0 && movementHorizontal == 0)
            return;
        if(!_lockRotation)
            Rotate(movement);

        _rb.AddForce(movement * _forcePower);
        if(_rb.velocity.magnitude > _maxMovementSpeed)
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxMovementSpeed);
    }
    
    private void Rotate(Vector3 target)
    {
        if(target == Vector3.zero)
            return;
        transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.normalized, Vector3.up), Time.deltaTime * _rotationSpeed);
    }

}
