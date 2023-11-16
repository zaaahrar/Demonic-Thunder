using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Assistant : MonoBehaviour
{
    [SerializeField] TMP_Text _infoText;
    [SerializeField] private GameObject _panelAssistant;
    private void Start()
    {
        _panelAssistant.SetActive(false);
    }

    public void OpenAssistant(string text)
    {
        _infoText.text = text;
        _panelAssistant.SetActive(true);
    }
}
