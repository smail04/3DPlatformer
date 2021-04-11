using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menuWindow;
    public MonoBehaviour[] scripts;

    public void OpenMenuWindow()
    {
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
        foreach (var script in scripts)
            if (script != null) script.enabled = false;
        Time.timeScale = 0.01f; 
    }

    public void CloseMenuWindow()
    {
        menuButton.SetActive(true);
        menuWindow.SetActive(false);
        foreach (var script in scripts)
            if (script != null) script.enabled = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Enemy.target = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
