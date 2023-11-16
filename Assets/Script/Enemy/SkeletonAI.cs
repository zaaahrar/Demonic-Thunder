using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : EnemyAI
{
    protected override void MovementBehavior()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);
        _animator.SetBool(_isRunHash, _isRun);

        if (!_enemy.IsDead)
        {
            if (distanceToPlayer <= _chaseDistance)
            {
                _isChasing = true;
                _isRun = true;
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _enemy.CurrentSpeed * Time.deltaTime);
                UpdateTurn(_player.position);

                if (Vector3.Distance(transform.position, _player.position) <= _attackRange)
                {
                    if (_canAttack)
                    {
                        Attack();
                    }
                }

                if (distanceToPlayer <= _stopDistance)
                {
                    _enemy.StopMovement();
                }
                else
                    _enemy.UpdateSpeed();

            }
            else if (_isChasing)
            {
                _isChasing = false;
            }

            if (_isChasing == false)
            {
                _isRun = false;
            }

            CheckSides();
        }
        else
            return;
    }
}
