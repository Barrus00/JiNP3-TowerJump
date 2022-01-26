using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    public void startLevel(int number)
    {
        SceneLoader.LoadScene(SceneNamesConsts.getLevel(number), null);
    }

    public void returnMainMenu()
    {
        SceneLoader.LoadScene(SceneNamesConsts.MAIN_MENU_SCENE_NAME, null);
    }
}
