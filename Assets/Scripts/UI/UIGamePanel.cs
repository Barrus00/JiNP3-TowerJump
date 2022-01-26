using UnityEngine;
using UnityEngine.UI;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField]
    private Text m_PointsText = null;

    [SerializeField]
    private GameObject m_PauseMenuRoot = null;

    [SerializeField]
    private GameObject m_GameOverText = null;

    [SerializeField]
    private GameObject m_WinMenuRoot = null;

    public void SetPoints(int points)
    {
        m_PointsText.text = points.ToString();
    }

    public void SetPauseMenuVisible(bool visible)
    {
        m_PauseMenuRoot.SetActive(visible);
    }

    public void SetGameOverTextVisible(bool visible)
    {
        m_GameOverText.SetActive(visible);
    }

    public void SetWinMenuVisible(bool visible)
    {
        m_WinMenuRoot.SetActive(visible);
    }
}