using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : Bar
{
    [SerializeField] private NightBorne _enemy;
    protected override void Start()
    {
        Slider.maxValue = _enemy.MaxHealth;
        Slider.value = _enemy.MaxHealth;
    }

    private void OnEnable()
    {
        _enemy.ChaingeBossHealthBar += UpdateSliderValue;
    }

    private void OnDisable()
    {
        _enemy.ChaingeBossHealthBar -= UpdateSliderValue;
    }
}
