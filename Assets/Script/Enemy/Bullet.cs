using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyDelay;
    [SerializeField] private int _damage;

    public float Speed => _speed;
    public float DestroyDelay => _destroyDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            Vector2 distance = transform.position - player.transform.position;
            player.TakeDamage(_damage, distance.x);
            Destroy(gameObject);
        }
    }
}
