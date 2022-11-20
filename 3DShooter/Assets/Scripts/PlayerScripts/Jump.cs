using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
    public void PhysicsJump()
    {
        if (_isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Force);
            _animator.SetTrigger("Jump");
        }
       
    }
}
