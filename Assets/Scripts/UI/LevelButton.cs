using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _buttonText;
    [SerializeField] private Image _starsImage;
    [SerializeField] private Sprite[] _starsSprites;
    private int _index;

    public void SetData(Progress progress, int index)
    {
        _buttonText.text = (index+1).ToString();
        _index = index;
        _button.interactable = progress.isOpened;
        _starsImage.sprite = _starsSprites[progress.starsCount];
    }

    public void LevelSelected()
    {
        LoadingScreen.Screen.Enable(true);
        LevelIndex levelIndex = new();
        levelIndex.SetIndex(_index);
        Debug.LogWarning(_index + " was selected");
        SceneLoader sceneLoader = new SceneLoader();
        sceneLoader.LoadingMenuScene(false);
    }
}
