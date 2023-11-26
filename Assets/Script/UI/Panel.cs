using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] protected GameObject Window; 

    public virtual void OpenPanel()
    {
        Window.SetActive(true);
        Time.timeScale = 0;
    }

    public virtual void ClosedPanel()
    {
        Window.SetActive(false);
        Time.timeScale = 1;
    }
}
