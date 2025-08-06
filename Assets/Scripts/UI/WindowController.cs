using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _endGameWindow;
    


    public void Play()
    {
        _gameState.SetState(State.Gameplay);
        _pauseWindow.SetActive(false);
    }

    public void NexLevel()
    {
        _endGameWindow.SetActive(false);
        /// need logic to start new level
    }

    public void Replay()
    {
        DisableTwoWindow();
        
    }

    public void ToHome()
    {
        DisableTwoWindow();
        LoadingScreen.Screen.Enable(true);
        SceneLoader loader = new SceneLoader();
        _gameState.SetState(State.Other);
        loader.LoadingMenuScene(true);
    }

    private void DisableTwoWindow()
    {
        _endGameWindow.SetActive(false);
        _pauseWindow.SetActive(false);
    }

    private void OnEnable()
    {
        BlockScript.OnEnded += EndGame;
    }

    private void OnDisable()
    {
        BlockScript.OnEnded -= EndGame;
    }

    private void EndGame()
    {
        if(_gameState.State == State.Gameplay)
        {
            _endGameWindow.SetActive(true);
        }
    }
}
