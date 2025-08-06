using UnityEngine;

public class AudioState 
{
    private AudioValues _audioValues = new AudioValues();
    private const string Key = "Audio";

    public AudioValues GetAudioValues()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            _audioValues = JsonUtility.FromJson<AudioValues>(PlayerPrefs.GetString(Key));
        }
        else
        {
            CreateKey();
        }
        return _audioValues;
    }
    private void CreateKey()
    {
        _audioValues.Music = true;
        _audioValues.Sound = true;
        SaveKey();
    }
    private void SaveKey()
    {
        string save = JsonUtility.ToJson(_audioValues);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }

    public void ClearKey()
    {
        PlayerPrefs.DeleteKey(Key);
    }

    public void EnableMusic(bool value)
    {
        _audioValues.Music = value;
        SaveKey();
    }
    public void EnableSound(bool value)
    {
        _audioValues.Sound = value;
        SaveKey();
    }

}

[System.Serializable]
public class AudioValues
{
    public bool Music;
    public bool Sound;
}

