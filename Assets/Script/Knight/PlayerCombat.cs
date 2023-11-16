using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
    [Header ("Inspector")]
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private bool _canAttack = true;

    private float _attackRange = 0.5f;
    private string _resetAttack = "ResetAttack";

    [Header("Componets")]
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Collider2D[] _enemyes;

    [Header("AnimationHash")]
    private int _isAttackHash = Animator.StringToHash("isAttack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.IsGround && _canAttack)
        {
            Attack();
        }
    }

    private void ResetAttack()
    {
        _canAttack = true;
    }

    private void Attack()
    {
        _animator.SetTrigger(_isAttackHash);

        _enemyes = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (var enemy in _enemyes)
        {
            if (enemy.TryGetComponent<Enemy>(out Enemy _enemy))
            {
                Vector3 direction = transform.position - _enemy.transform.position;

                _enemy.TakeDamage(_damage, direction.x);
            }
        }

        _canAttack = false;
        Invoke(_resetAttack, _attackCooldown);
    }
}
