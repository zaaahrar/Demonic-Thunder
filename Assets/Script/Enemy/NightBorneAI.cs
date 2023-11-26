using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAI : EnemyAI
{
    [SerializeField] private Transform[] _patrolPoints;

    private int _startPoint = 0;
    private int _endPoint = 1;
    private int _point = 0;
    private int _regenerationDelay = 5;
    private string _regenerationMehthod = "RegenerationHealth";

    protected override void Update()
    {
        MovementBehavior();

        if (_enemy.CurrentHealth <= _enemy.CurrentHealth / 2)
        {
            Invoke(_regenerationMehthod, _regenerationDelay);
        }
    }

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
                Patrol();
            }

            CheckSides();
        }
        else
            return;
    }

    protected void Patrol()
    {
        _isRun = true;
        transform.position = Vector3.MoveTowards(transform.position, _patrolPoints[_point].position, _enemy.CurrentSpeed * Time.deltaTime);
        UpdateTurn(_patrolPoints[_point].position);

        if (Vector2.Distance(transform.position, _patrolPoints[_point].position) < _distanceToPoint)
        {
            if (_point == _startPoint)
            {
                _point = _endPoint;
            }
            else
            {
                _point = _startPoint;
            }
        }
    }
}
