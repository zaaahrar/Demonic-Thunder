using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private int _chance = 50;
    private int _minChance = 0;
    private int _maxChance = 100;

    protected override void DropWeapon()
    {
        int random = Random.Range(_minChance, _maxChance);

        if (random <= _chance)
        {
            Instantiate(Weapon, transform.position, Quaternion.identity);
        }
        else
            return;
    }
}
