using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class EnemyAI : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] protected Transform _player;
    [SerializeField] protected Transform _attackPoint;
    [SerializeField] protected LayerMask _groundLayerMask;
    [SerializeField] protected LayerMask _playerLayerMask;
    [SerializeField] protected float _chaseDistance;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _rayDistance = 0.6f;

    protected bool _canAttack = true;
    protected bool _isChasing = false;
    protected bool _isRun = true;
    protected float _distanceToPoint = 0.2f;
    protected float _stopDistance = 1f;
    protected string _resetAttack = "ResetAttack";

    private Collider2D[] _anyColliders;
    private Vector3 _turnRight = new Vector3(1, 1, 1);
    private Vector3 _turnLeft = new Vector3(-1, 1, 1);

    [Header("Components")]
    protected Enemy _enemy;
    protected Rigidbody2D _rigidbody2D;
    protected Animator _animator;

    [Header("AnimationsHash")]
    protected static readonly int _isRunHash = Animator.StringToHash("isRun");
    protected static readonly int _isAttackHash = Animator.StringToHash("isAttack");



    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
    }

    protected virtual void Update()
    {
        MovementBehavior();
    }

    protected virtual void MovementBehavior() { }

    protected virtual void Attack()
    {
        _animator.SetTrigger(_isAttackHash);
        _anyColliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (var collider in _anyColliders)
        {
            if (collider.TryGetComponent<Player>(out Player player))
            {
                Vector2 distance = transform.position - _player.position;
                player.TakeDamage(_enemy.AttackDamage, distance.x);
            }
        }

        _canAttack = false;
        Invoke(_resetAttack, _enemy.AttackCooldown);
    }

    protected void UpdateTurn(Vector3 targetPosiont)
    {
        Vector3 direction = targetPosiont - transform.position;

        if (direction.x > 0)
        {
            transform.localScale = _turnRight;
        }

        if (direction.x < 0)
        {
            transform.localScale = _turnLeft;

        }
    }

    protected void ResetAttack()
    {
        _canAttack = true;
    }

    protected void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    protected void CheckSides()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, _rayDistance, _groundLayerMask);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, _rayDistance, _groundLayerMask);

        if (rightHit.collider != null || leftHit.collider != null)
        {
            Jump();
        }
    }
}
