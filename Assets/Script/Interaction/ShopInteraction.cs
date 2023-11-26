using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInteraction : Interaction
{
    protected override void Event()
    {
        _player.OnTaskComplited();
        _assistant.OpenAssistant("���� �������� ��� �� ������� ������������! ������������� � ������ �������.");
    }
}
