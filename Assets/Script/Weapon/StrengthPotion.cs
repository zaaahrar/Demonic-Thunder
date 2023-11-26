using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotion : Weapon
{
    [SerializeField] private int _strength;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.AddStrength(_strength);
            Destroy(gameObject);
        }
    }
}
