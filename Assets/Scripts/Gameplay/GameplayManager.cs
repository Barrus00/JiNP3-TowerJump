using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : ASingleton<GameplayManager>
{
    [SerializeField]
    private UIGamePanel m_UIGamePanel = null;

    [SerializeField]
    private int m_LevelNum = 1;

    private bool m_Paused = false;
    private bool m_GameFinished = false;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ToggleGameOverMenu()
    {
        TogglePause();
        m_GameFinished = true;

        m_UIGamePanel.SetGameOverTextVisible(true);
    }

    public void ToggleWinMenu()
    {
        SetPause(true);
        m_GameFinished = true;

        m_UIGamePanel.SetWinMenuVisible(true);
    }

    public void TogglePause()
    {
        SetPause(!m_Paused);
        m_UIGamePanel.SetPauseMenuVisible(m_Paused);
    }

    public void RestartLevel()
    {
        SceneLoader.LoadScene(SceneNamesConsts.getLevel(m_LevelNum), null);
    }

    public void GoToNextLevel()
    {
        SceneLoader.LoadScene(SceneNamesConsts.getLevel(m_LevelNum + 1), null);
    }
    
    public void GoToLevelSelectMenu()
    {
        SceneLoader.LoadScene(SceneNamesConsts.LEVEL_SELECT_SCENE, null);
    }

    public void GoToMainMenu()
    {
        SceneLoader.LoadScene(SceneNamesConsts.MAIN_MENU_SCENE_NAME, null);
    }

    private void SetPause(bool paused)
    {
        m_Paused = !m_Paused;
        Time.timeScale = m_Paused ? 0 : 1;
    }

    private void OnDestroy()
    {
        SetPause(false);
        m_GameFinished = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !m_GameFinished)
        {
            TogglePause();
        }
    }
}
