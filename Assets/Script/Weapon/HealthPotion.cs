using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Weapon
{
    [SerializeField] private int _health;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.RegenerateHealth(_health);
            Destroy(gameObject);
        }
    }
}
