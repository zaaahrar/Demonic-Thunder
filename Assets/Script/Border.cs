using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    private Vector3 _startPosition = new Vector3(-8.5f, -2.4f, 0);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.transform.position = _startPosition;
        }
    }
}
