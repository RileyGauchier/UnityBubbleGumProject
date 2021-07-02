using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _horizontalMove, _veritcalMove;
    [SerializeField] float _moveSpeed = 5f, _jumpForce = 10f;

    CharacterController _playerCC;
    Vector3 _moveDirection;

    private void Awake()
    {
        _playerCC = GetComponent<CharacterController>();
        _playerCC.detectCollisions = true;
    }

    private void FixedUpdate()
    {
        PlayerCharacterWalkInputs();
    }

    void PlayerCharacterWalkInputs()
    {
        _veritcalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(_horizontalMove, 0, _veritcalMove);
        Vector3 transformDirection = transform.TransformDirection(direction);

        Vector3 flatMovement = _moveSpeed * Time.deltaTime * transformDirection;

        _moveDirection = new Vector3(flatMovement.x, _moveDirection.y, flatMovement.z);

        transform.position += _moveDirection;
    }

    void PlayerCharacterJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
