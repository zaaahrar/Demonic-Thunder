using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : Enemy
{
    [SerializeField] private int _regenerationHealth;

    public override void RegeneraionHealth()
    {
        if (_currentHealth + _regenerationHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
            _currentHealth += _regenerationHealth;
    }
}
