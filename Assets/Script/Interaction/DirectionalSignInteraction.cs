using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSignInteraction : Interaction
{
    [SerializeField] private Collider2D _border;
    protected override void Event()
    {
        _assistant.OpenAssistant("�������� ���� ������! C��� �������� �� c������ ����������� �� ���� ���������� ��������� �����.");
        _border.isTrigger = true;
    }
}
