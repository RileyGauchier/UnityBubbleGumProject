using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _controller;
    Vector3 _playerDirection;
    float _horizontal, 
        _vertical, 
        _targetAngle,
        _turnSmoothVelocity;
    public float playerSpeed = 6f, 
        turnSmothTime = 0.1f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _playerDirection = new Vector3(_horizontal, 0f, _vertical).normalized;

        if(_playerDirection.magnitude >= 0.1f)
        {
            _targetAngle = Mathf.Atan2(_playerDirection.x, _playerDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                _targetAngle, 
                ref _turnSmoothVelocity, 
                turnSmothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _controller.Move(_playerDirection * playerSpeed * Time.deltaTime);
        }
    }
}
