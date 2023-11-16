using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] private int _level;
    [SerializeField] private int _experience;
    [SerializeField] private float _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _reboundForce;

    private Rigidbody2D _rigidbody2D;
    public UnityAction ChaingeHealthBar;

    public bool IsTaskComplited { get; private set; }
    public int MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, float direction)
    {
        _currentHealth -= damage;
        ChaingeHealthBar?.Invoke();

        if (direction > 0)
            _rigidbody2D.AddForce(Vector3.left * _reboundForce);

        if (direction < 0)
            _rigidbody2D.AddForce(Vector3.right * _reboundForce);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Вызовется панель смерти.
    }

    public void OnTaskComplited()
    {
        IsTaskComplited = true;
    }

    public void OnTaskUpdated()
    {
        IsTaskComplited = false;
    }
}
