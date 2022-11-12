using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float _frontMoveSpeed;
    [SerializeField] private float _backMoveSpeed;
    [SerializeField] private float _sideMoveSpeed;
    [SerializeField] private float _deadZone;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _spintSpeed;
    private float _temporarySpeed;
    private float _verticalJoystickAxis;
    private float _horizontalJoystickAxis;

   
    private void Update()
    {
        PlayersMove();
    }
    private void PlayersMove()
    {
        _verticalJoystickAxis = _joystick.Vertical;
        _horizontalJoystickAxis = _joystick.Horizontal;
        
        if (_verticalJoystickAxis >= _deadZone)
        {
            transform.localPosition += transform.forward * _frontMoveSpeed * Time.deltaTime;
            _animator.SetTrigger("Walking");
        }
        if (_verticalJoystickAxis <= -_deadZone)
        {
            transform.localPosition += -transform.forward * _backMoveSpeed * Time.deltaTime;
            _animator.SetTrigger("Walking");
        }
        if (_horizontalJoystickAxis >= _deadZone)
        {
            transform.localPosition += transform.right * _sideMoveSpeed * Time.deltaTime;
            _animator.SetTrigger("Walking");
        }
        if (_horizontalJoystickAxis <= -_deadZone)
        {
            transform.localPosition += -transform.right * _sideMoveSpeed * Time.deltaTime;
            _animator.SetTrigger("Walking");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
        
    }
    
    public void Sprint()
    {
        _temporarySpeed = _frontMoveSpeed;
        _frontMoveSpeed = _spintSpeed;
    }
    public void EndSprint()
    {
        _frontMoveSpeed = _temporarySpeed;
    }



}
