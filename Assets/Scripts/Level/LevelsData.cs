using System.Collections.Generic;
using UnityEngine;

public class LevelsData
{
    private const string KeyName = "Save";
    private LevelsProgressing _levelsProgressing = new LevelsProgressing();

    private void SaveData()
    {
        string saveJson = JsonUtility.ToJson(_levelsProgressing);
        PlayerPrefs.SetString(KeyName, saveJson);
        PlayerPrefs.Save();
    }

    public void NewData()
    {
        var levelsCount = Resources.LoadAll<GameLevel>("Levels").Length;

        for(int i = 0; i<levelsCount; i++)
        {
            _levelsProgressing.Levels.Add(new Progress());
            
        }
        _levelsProgressing.Levels[0].isOpened = true;
        SaveData();
        Resources.UnloadUnusedAssets();
    }

    public LevelsProgressing GetLevelsProgress()
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            string saveJson = PlayerPrefs.GetString(KeyName);
            _levelsProgressing = JsonUtility.FromJson<LevelsProgressing>(saveJson);
        }
        else
        {
            NewData();
        }
        return _levelsProgressing;
    }

    public void SaveLevelData(int index, Progress progress)
    {
        _levelsProgressing = GetLevelsProgress();
        _levelsProgressing.Levels[index] = progress;
        if(index < _levelsProgressing.Levels.Count - 1)
        {
            _levelsProgressing.Levels[index + 1].isOpened = true;
        }
        
        SaveData();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(KeyName);
    }
}
