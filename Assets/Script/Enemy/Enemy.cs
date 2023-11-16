using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header ("Inspector")]
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected Collider2D _playerCollider;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _currentSpeed;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackCooldown;
    [SerializeField] protected float _reboundForce;

    protected float _delayDeath = 5;

    [Header("Components")]
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    [Header ("AnimationsHash")]
    private int _hurtHash = Animator.StringToHash("Hurt");
    private int _isDeadHash = Animator.StringToHash("isDead");

    public float CurrentHealth => _currentHealth;
    public float CurrentSpeed => _currentSpeed;
    public float AttackCooldown => _attackCooldown;
    public int AttackDamage => _damage;

    public bool IsDead { get; private set; }

    protected void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        IsDead = false;
        _currentHealth = _maxHealth;
        _currentSpeed = _speed;
    }

    public void TakeDamage(int damage, float direction)
    {
        _currentHealth -= damage;
        _animator.SetTrigger(_hurtHash);

        if(direction > 0)
            _rigidbody2D.AddForce(Vector3.left * _reboundForce);

        if(direction < 0)
            _rigidbody2D.AddForce(Vector3.right * _reboundForce);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void StopMovement()
    {
        _currentSpeed = 0;
    }

    public void UpdateSpeed()
    {
        _currentSpeed = _speed;
    }

    protected void Die()
    {
        IsDead = true;
        _animator.SetBool(_isDeadHash, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _playerCollider, true);
        Destroy(gameObject, _delayDeath);
    }
}
