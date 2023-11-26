using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Inspector")]
    [SerializeField] private float _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _reboundForce;
    [SerializeField] private int _damage;
    [SerializeField] private Panel _panelDie;

    private float _killCounter = 0;
    private Rigidbody2D _rigidbody2D;
    public UnityAction<float> ChaingeHealthBar;
    public UnityAction<float> ChaingeProgressBar;

    public bool IsTaskComplited { get; private set; }
    public float KillCounter => _killCounter;
    public int MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public int Damage => _damage;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, float direction)
    {
        _currentHealth -= damage;
        ChaingeHealthBar?.Invoke(CurrentHealth);

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
        _panelDie.OpenPanel();
    }

    public void OnTaskComplited()
    {
        IsTaskComplited = true;
    }

    public void OnTaskUpdated()
    {
        IsTaskComplited = false;
    }

    public void AddKill()
    {
        _killCounter++;
        ChaingeProgressBar?.Invoke(_killCounter);
    }

    public void AddStrength(int value)
    {
        _damage += value;
    }

    public void RegenerateHealth(int value)
    {
        if (_currentHealth + value > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
            _currentHealth += value;

        ChaingeHealthBar?.Invoke(CurrentHealth);
    }
}
