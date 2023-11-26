using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : Bar
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private Assistant _assistant;

    private Enemy[] _enemys;

    protected override void Start()
    {
        _enemys = _parent.GetComponentsInChildren<Enemy>();
        Slider.maxValue = _enemys.Length;
        Slider.value = 0;
    }

    protected override void UpdateSliderValue(float value)
    {
        Slider.value = value;

        if (Slider.value == Slider.maxValue)
        {
            Player.OnTaskComplited();
            _assistant.OpenAssistant("Вы убили всех врагов. Выдвигайтесь в правую сторону.");
        }
    }

    private void OnEnable()
    {
        Player.ChaingeProgressBar += UpdateSliderValue;
    }

    private void OnDisable()
    {
        Player.ChaingeProgressBar -= UpdateSliderValue;
    }
}
