using UnityEngine;
using UnityEngine.UI;

public class ButtonsGenerator : MonoBehaviour
{
    [SerializeField] private Button _buttonPrefub;
    [SerializeField] private GameObject _content;

    private void Start()
    {
        Generate();
        
    }

    private void Generate()
    {
        LevelsData levelsData = new LevelsData();
        LevelsProgressing levelsProgressing = levelsData.GetLevelsProgress();


        for (int i = 0; i < levelsProgressing.Levels.Count; i++)
        {
           
            Button button = Instantiate(_buttonPrefub, _content.transform);
            if (button.gameObject.TryGetComponent(out LevelButton levelButton))
            {
                levelButton.SetData(levelsProgressing.Levels[i], i );
            }
        }
        LoadingScreen.Screen.Enable(false);
    }
}
