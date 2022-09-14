using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            IsPaused = !IsPaused;
            pauseMenu.SetActive(IsPaused);
            
        }
    }
    public static void Pause()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }
    public static void UnPause()
    {
        Time.timeScale = 1;
        IsPaused = false;
    }
}
