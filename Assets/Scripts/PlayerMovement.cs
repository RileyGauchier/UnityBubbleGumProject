using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f, _jumpForce = 10f;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        PlayerCharacterWalkInputs();
    }

    void PlayerCharacterWalkInputs()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(_moveSpeed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(_moveSpeed * -Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(_moveSpeed * Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(_moveSpeed * -Vector3.right);
        }
    }

    void PlayerCharacterJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
