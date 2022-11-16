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
        _animator.SetFloat("Vertical", _verticalJoystickAxis);
        _animator.SetFloat("Horizontal", _horizontalJoystickAxis);
        if (_verticalJoystickAxis >= _deadZone)
        {
            transform.localPosition += transform.forward * _frontMoveSpeed * Time.deltaTime;
         

        }
        if (_verticalJoystickAxis <= -_deadZone)
        {
            transform.localPosition += -transform.forward * _backMoveSpeed * Time.deltaTime;
           

        }
        if (_horizontalJoystickAxis >= _deadZone)
        {
            transform.localPosition += transform.right * _sideMoveSpeed * Time.deltaTime;
          
        }
        if (_horizontalJoystickAxis <= -_deadZone)
        {
            transform.localPosition += -transform.right * _sideMoveSpeed * Time.deltaTime;
          
        }
        if (_horizontalJoystickAxis ==0 && _verticalJoystickAxis == 0)
        {
            _animator.SetTrigger("Idle");
        }
        else
        {
            _animator.SetTrigger("Walking");
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
