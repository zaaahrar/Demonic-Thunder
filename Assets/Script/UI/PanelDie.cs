using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelDie : Panel
{
    [SerializeField] private SceneTransition _sceneTransition;

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(_sceneTransition.NumberScene);   
        Time.timeScale = 1;
    }
}
