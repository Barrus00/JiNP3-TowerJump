public static class SceneNamesConsts
{
    public const string MAIN_MENU_SCENE_NAME = "MainMenu";
    public const string LEVEL_SELECT_SCENE = "LevelSelect";
    public const string FIRST_LEVEL = "Level1";
    public const string SECOND_LEVEL = "Level2";
    public const string THIRD_LEVEL = "Level3";
    public const string FOURTH_LEVEL = "Level4";

    public static string getLevel(int level_number)
    {
        return $"Level{level_number}";
    }
}
