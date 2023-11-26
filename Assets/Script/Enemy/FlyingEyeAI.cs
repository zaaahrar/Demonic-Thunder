using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeAI : EnemyAI
{
    [SerializeField] private Bullet _bulletTemplate;

    protected override void MovementBehavior()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        _animator.SetBool(_isRunHash, _isRun);

        if (!_enemy.IsDead)
        {
            if (distanceToPlayer <= _attackRange && _canAttack)
            {
                Attack();
            }

            if (distanceToPlayer <= _chaseDistance)
            {
                Vector2 direction = (_player.position - transform.position).normalized;
                transform.Translate(new Vector2((direction.x * -1 * _enemy.CurrentSpeed) * Time.deltaTime, 0));
                UpdateTurn(_player.position);
            }

                CheckSides();
        }
        else
            return;
    }

    protected override void Attack()
    {
        var bullet = Instantiate(_bulletTemplate, transform.position, Quaternion.identity);
        Vector2 direction = (_player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletTemplate.Speed;
        Destroy(bullet.gameObject, _bulletTemplate.DestroyDelay);
        _canAttack = false;
        Invoke(_resetAttack, _enemy.AttackCooldown);
    }
}
