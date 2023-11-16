using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _sliderHealth.maxValue = _player.MaxHealth;
        _sliderHealth.value = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.ChaingeHealthBar += UpdateSliderValue;
    }

    private void OnDisable()
    {
        _player.ChaingeHealthBar -= UpdateSliderValue;
    }

    private void UpdateSliderValue()
    {
        _sliderHealth.value = _player.CurrentHealth;
    }
}
