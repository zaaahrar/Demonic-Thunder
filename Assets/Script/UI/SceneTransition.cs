using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int _numberScene;
    [SerializeField] private Panel _panelWin;
    [SerializeField] private bool isFinalScen = false;

    public int NumberScene => _numberScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) && player.IsTaskComplited)
        {
            if(isFinalScen)
            {
                _panelWin.OpenPanel();
            }
            else
            {
                SceneManager.LoadScene(_numberScene);
                player.OnTaskUpdated();
            }
        }
    }
}
