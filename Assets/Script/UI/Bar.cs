using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] protected Slider Slider;

    protected virtual void Start() { }

    protected virtual void UpdateSliderValue(float value)
    {
        Slider.value = value;
    }
}
