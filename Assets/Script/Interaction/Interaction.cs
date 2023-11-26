using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    [SerializeField] protected Assistant _assistant;
    protected Player _player;

    protected virtual void Event() { }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            Event();
            Destroy(gameObject);
        }
    }
}
