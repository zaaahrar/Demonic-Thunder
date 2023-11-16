using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int _numberScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) && player.IsTaskComplited)
        {
            SceneManager.LoadScene(_numberScene);
            player.OnTaskUpdated();
        }
    }
}
