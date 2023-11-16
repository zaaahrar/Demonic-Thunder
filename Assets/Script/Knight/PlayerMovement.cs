using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _isGround;
    [SerializeField] private float _speed;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;

    private Vector3 _turnRight = new Vector3(1, 1, 1);
    private Vector3 _turnLeft = new Vector3(-1, 1, 1);
    private float _rayDistance = 0.7f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private int _isRunHash = Animator.StringToHash("isRun");
    private int _isGroundHash = Animator.StringToHash("isGround");

    public bool IsGround => _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentSpeed = _speed;
    }

    private void Update()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.localScale = _turnRight;
            transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
            _animator.SetBool(_isRunHash, true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
                Jump();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.localScale = _turnLeft;
            transform.Translate(-_currentSpeed * Time.deltaTime, 0, 0);
            _animator.SetBool(_isRunHash, true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
                Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            Jump();
        else
        {
            _animator.SetBool(_isRunHash, false);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _rayDistance, _groundLayerMask);
        _isGround = hit.collider != null;
        _animator.SetBool(_isGroundHash, _isGround);
    }
}
