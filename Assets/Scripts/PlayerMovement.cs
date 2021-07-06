using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask _groundLayer = default;
    [SerializeField] float _moveSpeed = 5f, _jumpForce = 1f;
    float _xMove,_zMove;
    Rigidbody _rb;
    CapsuleCollider _cc;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponentInChildren<CapsuleCollider>();

    }

    private void FixedUpdate()
    {
        PlayerCharacterWalkInputs();
        PlayerCharacterJump();
    }

    void PlayerCharacterWalkInputs()
    {
        _xMove = Input.GetAxisRaw("Horizontal");
        _zMove = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector3(_xMove, _rb.velocity.y, _zMove) * _moveSpeed;
    }

    void PlayerCharacterJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(_cc.bounds.center, new Vector3(_cc.bounds.center.x
            , _cc.bounds.min.y,
            _cc.bounds.center.z),
            _cc.radius * 0.9f,
            _groundLayer);
    }
}
