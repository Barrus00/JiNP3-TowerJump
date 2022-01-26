using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuController : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneLoader.LoadScene(SceneNamesConsts.LEVEL_SELECT_SCENE, HandleSceneLoaded);
    }

    private void HandleSceneLoaded(Scene scene)
    {
        Debug.Log($"Loaded scene {scene.name}!");
    }
}
