using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] protected TMP_Text _massage;

    private void Start()
    {
        _massage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _massage.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _massage.enabled = false;
        }
    }
}
