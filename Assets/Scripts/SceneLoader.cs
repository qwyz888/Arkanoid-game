using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private const string Menu = "Menu";
    private const string Game = "Game";

    public void LoadingMenuScene(bool value)
    {
        SceneManager.LoadSceneAsync(value ? Menu : Game);
    }
}
