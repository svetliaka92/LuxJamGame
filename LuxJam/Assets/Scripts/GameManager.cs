using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] private Image fadeScreen;
    [SerializeField] private GameObject pauseScreen;

    private Color fadeScreenColor;
    private bool isPaused = false;
    public bool IsPaused => isPaused;

    string sceneToLoad = "";
    int sceneIndexToLoad = -1;

    private void Awake()
    {
        _instance = this;
        fadeScreenColor = fadeScreen.color;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
            LoadWinScene();
        else if (Input.GetKeyDown(KeyCode.L))
            LoadLoseScene();
#endif
    }

    public void LoadScene(string sceneName)
    {
        UnpauseGame();

        sceneToLoad = sceneName;

        FadeInScreen();
    }

    public void LoadScene(int sceneIndex)
    {
        UnpauseGame();

        sceneIndexToLoad = sceneIndex;

        FadeInScreen();
    }

    private void FadeInScreen()
    {
        LeanTween.value(0, 1, 1f)
                 .setEaseOutCubic()
                 .setOnUpdate(UpdateFadeScreenAlpha)
                 .setOnComplete(LoadSceneActual);
    }

    private void LoadSceneActual()
    {
        if (!String.IsNullOrEmpty(sceneToLoad))
            SceneManager.LoadScene(sceneToLoad);
        else if (sceneIndexToLoad != -1)
            SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void WinGame()
    {
        LoadWinScene();
    }

    public void LoseGame()
    {
        LoadLoseScene();
    }

    internal void PauseGame()
    {
        isPaused = true;

        pauseScreen.SetActive(true);
        UpdateMouseCursor(isPaused);
    }

    public void UnpauseGame()
    {
        isPaused = false;

        pauseScreen.SetActive(false);
        UpdateMouseCursor(isPaused);
    }

    private void UpdateFadeScreenAlpha(float val)
    {
        fadeScreenColor.a = val;
        fadeScreen.color = fadeScreenColor;
    }

    private void LoadWinScene()
    {
        LoadScene("WinScene");
    }

    private void LoadLoseScene()
    {
        LoadScene("LoseScene");
    }

    private void UpdateMouseCursor(bool isGamePaused)
    {
        if (isGamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // fade out the fade screen
        LeanTween.value(1, 0, 0.7f)
                 .setEaseInCubic()
                 .setOnUpdate(UpdateFadeScreenAlpha);

        if (scene.buildIndex != 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
