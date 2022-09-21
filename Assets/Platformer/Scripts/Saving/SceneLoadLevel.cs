using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadLevel : MonoBehaviour
{
    private string _loadedSceneName;
    private SaveGameManager _saveGameManager;
  
    public void LoadLevel(string sceneName)
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        _loadedSceneName = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == _loadedSceneName)
        {
            _saveGameManager = FindObjectOfType<SaveGameManager>();
            if (_saveGameManager == null)
            {
                Destroy(gameObject);
                return;
            }
            
            _saveGameManager.LoadGame();
        }
        
        Destroy(gameObject);
    }
}
