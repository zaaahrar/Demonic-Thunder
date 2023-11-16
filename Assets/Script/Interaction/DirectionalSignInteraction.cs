using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSignInteraction : Interaction
{
    [SerializeField] private Collider2D _border;
    protected override void Event()
    {
        _assistant.OpenAssistant("Одолейте всех врагов! Cвой прогресс вы cможете отслеживать по мере заполнения оранжевой шкалы.");
        _border.isTrigger = true;
    }
}
