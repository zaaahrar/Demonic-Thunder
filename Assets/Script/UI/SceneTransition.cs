using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int _numberScene;
    [SerializeField] private Panel _panelWin;
    private int finalScene = 3;

    public int NumberScene => _numberScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) && player.IsTaskComplited)
        {
            if(_numberScene == finalScene)
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
