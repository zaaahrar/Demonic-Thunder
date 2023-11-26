using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    protected override void Start()
    {
        Slider.maxValue = Player.MaxHealth;
        Slider.value = Player.MaxHealth;
    }

    private void OnEnable()
    {
        Player.ChaingeHealthBar += UpdateSliderValue;
    }

    private void OnDisable()
    {
        Player.ChaingeHealthBar -= UpdateSliderValue;
    }
}
